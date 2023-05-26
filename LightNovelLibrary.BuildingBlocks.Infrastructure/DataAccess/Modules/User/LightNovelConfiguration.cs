using X = LightNovelLibrary.Modules.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.User;

public class LightNovelConfiguration : IEntityTypeConfiguration<X.LightNovel>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<X.LightNovel> builder)
    {
        //够了，User模块不会创建LightNovel!!!
        builder.HasKey(e => e.LightNovelId);
    }
}

