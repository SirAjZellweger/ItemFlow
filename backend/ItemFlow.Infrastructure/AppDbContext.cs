using ItemFlow.Infrastructure.Dbos;

using Microsoft.EntityFrameworkCore;

namespace ItemFlow.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ItemDbo> Items => Set<ItemDbo>();
    public DbSet<CheckoutDbo> Checkouts => Set<CheckoutDbo>();
    public DbSet<CheckoutItemDbo> CheckoutItems => Set<CheckoutItemDbo>();

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

            entity.Property(e => e.Quantity)
                .IsRequired();

            entity.HasMany(i => i.CheckoutItems)
                .WithOne(ci => ci.Item)
                .HasForeignKey(ci => ci.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CheckoutDbo>(entity =>
        {
            entity.ToTable("Checkout");
            entity.HasKey(c => c.Id);

            entity.Property(c => c.StartDate)
                .IsRequired();

            entity.Property(c => c.PlannedEndDate);

            entity.Property(c => c.ActualEndDate);

            entity.HasMany(c => c.Items)
                .WithOne(ci => ci.Checkout)
                .HasForeignKey(ci => ci.CheckoutId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<CheckoutItemDbo>(entity =>
        {
            entity.ToTable("CheckoutItem");
            entity.HasKey(ci => ci.Id);

            entity.Property(ci => ci.Quantity)
                .IsRequired();

            entity.Property(ci => ci.ReturnedAt);

            entity.HasOne(ci => ci.Item)
                .WithMany(i => i.CheckoutItems)
                .HasForeignKey(ci => ci.ItemId);

            entity.HasOne(ci => ci.Checkout)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CheckoutId);
        });

        base.OnModelCreating(modelBuilder);
    }

}
