using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.LightNovel;
using LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;

/// <summary>
/// 
/// LightNovel Domain范围内的Context，每个模块内实现自己的Context
/// 
/// </summary>
public class LightNovelDbContext : DbContext
{
    public LightNovelDbContext(DbContextOptions<LightNovelDbContext> options) : base(options)
    {
    }


    public DbSet<LightNovel> LightNovels { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Edition> Editions { get; set; }

    public DbSet<Chaptor> Chaptors { get; set; }


    /// <summary>
    /// 配置model关系
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LightNovelConfiguration());
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new EditionConfiguration());  
        modelBuilder.ApplyConfiguration(new ChaptorConfiguration());
    }

}

