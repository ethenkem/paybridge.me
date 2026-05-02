using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts;
using PayBridge.Features.Users;


namespace PayBridge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(x => x.UserId);
        });
    }
}

