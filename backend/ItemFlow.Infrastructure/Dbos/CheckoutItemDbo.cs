namespace ItemFlow.Infrastructure.Dbos;

public class CheckoutItemDbo
{
    public required Guid Id { get; set; }
    public required Guid CheckoutId { get; set; }
    public required Guid ItemId { get; set; }
    public int Quantity { get; set; }
    public DateTime? ReturnedAt { get; set; }

    // Navigation Properties
    public CheckoutDbo Checkout { get; set; } = null!;
    public ItemDbo Item { get; set; } = null!;
}
