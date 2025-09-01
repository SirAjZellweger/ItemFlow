namespace ItemFlow.Infrastructure.Dbos;

public class CheckoutDbo
{
    public required Guid Id { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? PlannedEndDate { get; set; }
    public DateTime? ActualEndDate { get; set; }

    // Navigation Properties
    public ICollection<CheckoutItemDbo> Items { get; set; } = [];
}
