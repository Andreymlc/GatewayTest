using Microsoft.EntityFrameworkCore;

namespace GatewayTest;

public class ElementDbContext(DbContextOptions<ElementDbContext> options) : DbContext(options)
{
    public DbSet<Element> Elements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ElementConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseSnakeCaseNamingConvention();
        if (!optionsBuilder.IsConfigured)
            throw new InvalidOperationException("context is not configured");
        base.OnConfiguring(optionsBuilder);
    }
}