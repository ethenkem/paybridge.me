using Microsoft.EntityFrameworkCore;
using PayBridge.Features.Contracts;


namespace PayBridge.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}

