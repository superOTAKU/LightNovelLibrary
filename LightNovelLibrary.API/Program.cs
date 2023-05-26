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

// ������ʹ���ڴ����ݿ⣡����
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

// FIXME pipeline behavior��Ӧ�õ����е�handler...
// ���Կ����Զ������ԣ���behavior�У�ͨ�������ж�handler�Ƿ�����
builder.Services.AddMediatR(cfg =>
{
    //��ȡ��ǰ�������õ��������򼯣���ִ������ע��
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies().Select(Assembly.Load).ToArray());
})
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
    .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRequestBehavior<,>));

// ��֤����Ȩ
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // Ĭ�ϵ���֤��������
    .AddJwtBearer(/* ��ӵĲ������� */JwtBearerDefaults.AuthenticationScheme, options => 
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
    //���������������кŸ�ʽ
    opt.JsonSerializerOptions.Converters.Add(new DateTimeConvertor());
});

//Ĭ�ϴ�����
builder.Services.AddProblemDetails();
//���Ʒ��صĴ���DTO��ʽ
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

//�����м��������ҵ���쳣
app.UseExceptionHandler();

//��ʼ��DB
DataSeed.Seed(app);

app.Run();
