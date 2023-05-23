using LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;

/// <summary>
/// 整个应用的持久层配置 all in one
/// 
/// 也可以每个module一个context，但实现起来比较复杂...
/// 
/// </summary>
public class AppDbContext : DbContext
{
    
    public DbSet<LightNovel> LightNovels { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Edition> Editions { get; set; }

    public DbSet<Chaptor> Chaptors { get; set; }


}

