namespace ItemFlow.Domain.Items;

public class Item
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required int Quantity { get; init; }

    public static Item Create(string name, string? description = null, int quantity = 1)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name darf nicht leer sein.", nameof(name));

        return new Item
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Quantity = quantity
        };
    }
}
