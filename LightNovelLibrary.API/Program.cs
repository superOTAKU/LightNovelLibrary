using FluentValidation;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Behaviors;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidatorsFromAssemblies(Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies().Select(Assembly.Load));
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
