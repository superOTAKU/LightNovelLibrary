using FluentValidation;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Behaviors;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Convertors;
using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;
using LightNovelLibrary.Modules.LightNovel.Domain;
using LightNovelLibrary.Modules.LightNovel.Infrastructure;
using LightNovelLibrary.Modules.LightNovel.Infrastructure.Repositories;
using LightNovelLibrary.Modules.User.Domain;
using LightNovelLibrary.Modules.User.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using LightNovelLibrary.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Security;
using LightNovelLibrary.API.Security;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies().Select(Assembly.Load));

// 初期先使用内存数据库！！！
builder.Services.AddDbContext<LightNovelDbContext>(opt =>
{
    opt.UseInMemoryDatabase("LightNovelLibrary");
});
builder.Services.AddDbContext<UserDbContext>(opt =>
{
    opt.UseInMemoryDatabase("LightNovelLibrary");
});
builder.Services.AddScoped<LightNovelUnitOfWork>();
builder.Services.AddScoped<ILightNovelRepository, LightNovelRepository>();
builder.Services.AddScoped<UserUnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ISecurityKeyProvider, SecurityKeyProvider>();

// FIXME pipeline behavior会应用到所有的handler...
// 可以考虑自定义特性，在behavior中，通过特性判断handler是否拦截
builder.Services.AddMediatR(cfg =>
{
    //获取当前程序集引用的其他程序集，并执行依赖注入
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies().Select(Assembly.Load).ToArray());
})
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRequestBehavior<,>));

// 验证与授权
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // 默认的验证策略名称
    .AddJwtBearer(/* 添加的策略名称 */JwtBearerDefaults.AuthenticationScheme, options => 
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidateAudience = true,
            ValidAudience = jwtSettings["Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyProvider.ReadPublicKey(builder.Configuration["JwtSettings:PublicKey"]!),
            ValidateLifetime = true
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    //定制日期类型序列号格式
    opt.JsonSerializerOptions.Converters.Add(new DateTimeConvertor());
});

//默认错误处理
builder.Services.AddProblemDetails();
//定制返回的错误DTO格式
builder.Services.Decorate<ProblemDetailsFactory, ProblemDetailsFactoryDecorator>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//增加中间件以拦截业务异常
app.UseExceptionHandler();

//初始化DB
DataSeed.Seed(app);

app.Run();
