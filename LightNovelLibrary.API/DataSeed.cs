using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using LightNovelLibrary.Modules.LightNovel.Domain;
using LightNovelDomain = LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LightNovelLibrary.API;

public class DataSeed : ControllerBase
{

    public static void Seed(WebApplication app)
    {
        // 填充初始数据
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<LightNovelDbContext>();
        if (context.Authors.Count() == 0)
        {
            context.Authors.Add(new Author
            {
                AuthorId = 1,
                Name = "尾田",
                Gender = Gender.Male
            });
            context.Tags.Add(new Tag
            {
                TagId = 1,
                Name = "热血"
            });
            context.LightNovels.Add(new LightNovelDomain.LightNovel
            {
                Name = "One Piece",
                Status = LightNovelStatus.Serializing,
                UpdateTime = DateTime.UtcNow,
                AuthorId = 1,
                LightNovelTags =
            {
                new LightNovelTag
                {
                    TagId = 1
                }
            }
            });
            context.SaveChanges();
            Console.WriteLine("初始化数据库完成");
        }
    }

}
