using LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.LightNovel;

public class EditionConfiguration : IEntityTypeConfiguration<Edition>
{
    public void Configure(EntityTypeBuilder<Edition> builder)
    {
        builder.HasKey(e => e.EditionId)
            .HasAnnotation("idGenerator", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));

        //配置和chaptor的关系，一对多
        builder.HasMany(e => e.Chaptors)
            .WithOne(e => e.Edition)
            .HasForeignKey(e => e.EditionId);
    }
}

