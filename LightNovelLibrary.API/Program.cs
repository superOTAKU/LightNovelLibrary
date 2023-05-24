using FluentValidation;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Behaviors;
using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;
using LightNovelLibrary.Modules.LightNovel.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies().Select(Assembly.Load));

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

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.Decorate<ProblemDetailsFactory, ProblemDetailsFactoryDecorator>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

// 填充初始数据
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (context.Authors.Count() == 0)
    {
        context.Authors.Add(new Author { AuthorId = 1, Name = "尾田", Gender = Gender.Male });
    }
}

app.Run();
