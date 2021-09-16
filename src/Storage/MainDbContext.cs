using Microsoft.EntityFrameworkCore;
using PredictionPlanner.Storage.Entities;

namespace PredictionPlanner.Storage;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Prediction> Predictions { get; set; } = default!;
    public DbSet<ApplicationUser> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>(b =>
        {
            b.HasKey(u => u.Id);
            b.HasIndex(u => u.NormalizedEmail)
                .HasDatabaseName("EmailIndex")
                .IsUnique();

            b.Property(u => u.Email)
                .HasMaxLength(256);

            b.Property(u => u.NormalizedEmail)
                .HasMaxLength(256);

            b.Property(u => u.PasswordHash)
                .HasMaxLength(300);

            b.HasMany(u => u.Predictions)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .IsRequired();
        });

        modelBuilder.Entity<Prediction>(b =>
        {
            b.HasKey(p => p.Id);
        });
    }
}
