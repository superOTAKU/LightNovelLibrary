using FluentValidation;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Behaviors;
using MediatR;
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

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
