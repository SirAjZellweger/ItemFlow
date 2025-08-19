namespace ItemFlow.Domain.Items;

public class Item
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }

    public static Item Create(string name, string? description = null)
    {
        return string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentException("Name darf nicht leer sein.", nameof(name))
            : new Item
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
    }
}
