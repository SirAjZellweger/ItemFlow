namespace ItemFlow.Domain.Checkouts;

public class Checkout
{
    public Guid Id { get; init; }
    public DateTime? PlannedStartDate { get; init; }
    public DateTime? StartDate { get; private set; }
    public DateTime? PlannedEndDate { get; init; }
    public DateTime? EndDate { get; private set; }

    private readonly List<CheckoutItem> _items = [];
    public IReadOnlyList<CheckoutItem> Items => _items.AsReadOnly();

    public static Checkout Create(IEnumerable<CheckoutItem> items, DateTime? plannedStartDate = null, DateTime? plannedEndDate = null)
    {
        if (!items.Any())
            throw new InvalidOperationException("Ein Checkout muss mindestens ein Item enthalten.");

        DateTime now = DateTime.UtcNow;

        if (plannedStartDate.HasValue && plannedStartDate.Value < now)
            throw new InvalidOperationException("Das geplante Startdatum darf nicht in der Vergangenheit liegen.");

        if (plannedEndDate.HasValue && plannedStartDate.HasValue && plannedEndDate.Value < plannedStartDate.Value)
            throw new InvalidOperationException("Das geplante Enddatum darf nicht vor dem geplanten Startdatum liegen.");


        Checkout checkout = new()
        {
            Id = Guid.NewGuid(),
            PlannedStartDate = plannedStartDate,
            PlannedEndDate = plannedEndDate
        };

        foreach (CheckoutItem item in items)
            checkout.AddItem(item);

        return checkout;
    }

    public void AddItem(CheckoutItem item)
    {
        if (_items.Any(i => i.Item.Id == item.Item.Id))
            throw new Exception("Item bereits in diesem Checkout vorhanden.");

        _items.Add(item);
    }

    public void Start()
    {
        if (StartDate.HasValue)
            throw new InvalidOperationException("Checkout wurde bereits gestartet.");

        DateTime startDate = DateTime.UtcNow;

        if (PlannedEndDate.HasValue && PlannedEndDate.Value < startDate)
            throw new InvalidOperationException("Das geplante Enddatum darf nicht vor dem Startdatum liegen.");

        StartDate = startDate;
    }

    public void End()
    {
        DateTime actualEndDate = DateTime.UtcNow;

        if (EndDate.HasValue)
            throw new Exception("Die Ausleihe wurde bereits beendet.");

        if (actualEndDate < StartDate)
            throw new Exception("Das Enddatum darf nicht vor dem Startdatum liegen.");

        EndDate = actualEndDate;
    }
}
