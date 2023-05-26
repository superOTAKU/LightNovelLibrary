using LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.LightNovel;

public class ChaptorConfiguration : IEntityTypeConfiguration<Chaptor>
{
    public void Configure(EntityTypeBuilder<Chaptor> builder)
    {
        builder.HasKey(e => e.ChaptorId)
            .HasAnnotation("idGenerator", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));
    }
}

