namespace ItemFlow.Infrastructure.Dbos;

public class ItemDbo
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
