using X = LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.LightNovel;

public class LightNovelConfiguration : IEntityTypeConfiguration<X.LightNovel>
{
    public void Configure(EntityTypeBuilder<X.LightNovel> builder)
    {
        builder.HasKey(x => x.LightNovelId)
            .HasAnnotation("idGenerator", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));

        // 配置和Author之间的关系，一对多
        builder.HasOne(e => e.Author)
            .WithMany(e => e.LightNovels)
            .HasForeignKey(e => e.AuthorId);

        // 配置和Tag的关系，多对多
        builder.HasMany(e => e.Tags)
            .WithMany(e => e.LightNovels)
            .UsingEntity<X.LightNovelTag>(cfg =>
            {
                cfg.HasOne(e => e.LightNovel).WithMany(e => e.LightNovelTags).HasForeignKey(e => e.LightNovelId);
                cfg.HasOne(e => e.Tag).WithMany(e => e.LightNovelTags).HasForeignKey(e => e.TagId);
            });

        //配置和edition的关系，一对多
        builder.HasMany(e => e.Editions)
            .WithOne(e => e.LightNovel)
            .HasForeignKey(e => e.LightNovelId);

        //配置和chaptor的关系，一对多
        builder.HasMany(e => e.Chaptors)
            .WithOne(e => e.LightNovel)
            .HasForeignKey(e => e.LightNovelId);
    }
}

