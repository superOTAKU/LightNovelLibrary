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

// ����ʼ����
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (context.Authors.Count() == 0)
    {
        context.Authors.Add(new Author { AuthorId = 1, Name = "β��", Gender = Gender.Male });
    }
}

app.Run();
