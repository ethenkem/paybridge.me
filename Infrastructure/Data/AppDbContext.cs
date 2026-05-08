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
    // public DbSet<Milestone> Milestones => Set<Milestone>();
    public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AppDbContext).Assembly
        );

    }
}

