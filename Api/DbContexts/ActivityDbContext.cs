using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.DbContexts;

public class ActivityDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DbSet<Activity> Activities { get; set; }

    public ActivityDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration["ConnectionString"];

        optionsBuilder.UseNpgsql(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>()
            .HasKey(x => x.Id);
    }
}