using ItemFlow.Domain.Items;

namespace ItemFlow.Domain.Checkouts;

public class CheckoutItem
{
    public Guid Id { get; init; }
    public required Item Item { get; init; }
    public int Quantity { get; private set; }
    public DateTime? ReturnedAt { get; private set; }

    public static CheckoutItem Create(Item item, int quantity = 1)
    {
        if (quantity < 1)
            throw new ArgumentException("Die Menge muss mindestens 1 betragen.");

        if (quantity > item.Quantity)
            throw new ArgumentException($"Die Menge darf den Gesamtbestand des Gegenstands ({item.Quantity}) nicht überschreiten.");

        return new CheckoutItem
        {
            Id = Guid.NewGuid(),
            Item = item,
            Quantity = quantity
        };
    }

    public void MarkReturned(DateTime returnedAt)
    {
        ReturnedAt = returnedAt;
    }
}

