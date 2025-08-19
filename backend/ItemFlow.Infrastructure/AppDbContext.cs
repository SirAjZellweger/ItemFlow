using ItemFlow.Infrastructure.DBOs;

using Microsoft.EntityFrameworkCore;

namespace ItemFlow.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ItemDbo> Items { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemDbo>(entity =>
        {
            entity.ToTable("Item");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            entity.Property(e => e.Description)
                  .HasMaxLength(500);
        });

        base.OnModelCreating(modelBuilder);
    }

}
