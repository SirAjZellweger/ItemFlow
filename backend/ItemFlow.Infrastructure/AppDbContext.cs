using Microsoft.EntityFrameworkCore;

namespace ItemFlow.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DummyDbo>(entity =>
        {
            entity.ToTable("Dummy");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        });

        base.OnModelCreating(modelBuilder);
    }

}
