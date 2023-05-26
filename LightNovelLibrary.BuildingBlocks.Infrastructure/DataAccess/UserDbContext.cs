using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess.Modules.User;
using LightNovelLibrary.Modules.User.Domain;
using Microsoft.EntityFrameworkCore;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {    
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new LightNovelConfiguration());
    }

}

