using APD.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace APD.DAL;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}

    public DbSet<User> Users => Set<User>();
    public DbSet<Installation> Installations => Set<Installation>();
    public DbSet<PrintDevice> PrintDevices => Set<PrintDevice>();
    public DbSet<Office> Offices => Set<Office>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(b => b.MigrationsAssembly("APD"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User", "main");
        });
        
        modelBuilder.Entity<Installation>(entity =>
        {
            entity.ToTable("Installation", "main");
        });
        
        modelBuilder.Entity<PrintDevice>(entity =>
        {
            entity.ToTable("PrintDevice", "main");
        });
        
        modelBuilder.Entity<Office>(entity =>
        {
            entity.ToTable("Office", "main");
        });
    }
}