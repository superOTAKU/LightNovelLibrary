using X = LightNovelLibrary.Modules.User.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using LightNovelLibrary.Modules.User.Domain;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.User;

public class UserConfiguration : IEntityTypeConfiguration<X.User>
{
    public void Configure(EntityTypeBuilder<X.User> builder)
    {
        builder.HasKey(e => e.UserId)
            .HasAnnotation("idGenerator", new DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity));

        //和LightNovel的关系
        builder.HasMany(e => e.LightNovels)
            .WithMany(e => e.Users)
            .UsingEntity<UserLightNovel>(cfg =>
            {
                cfg.HasOne(e => e.User)
                    .WithMany(e => e.UserLightNovels)
                    .HasForeignKey(e => e.UserId);
                cfg.HasOne(e => e.LightNovel)
                    .WithMany(e => e.UserLightNovels)
                    .HasForeignKey(e => e.LightNovelId);
            });
    }
}

