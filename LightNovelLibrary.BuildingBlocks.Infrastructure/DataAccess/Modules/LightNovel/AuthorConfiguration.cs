using LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.LightNovel;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.HasKey(e => e.AuthorId)
            .HasAnnotation("idGenerator", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));
    }
}

