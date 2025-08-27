using ItemFlow.Domain.Items;
using ItemFlow.Infrastructure.Dbos;

namespace ItemFlow.Infrastructure.Mappers;

public static class ItemMapper
{
    public static Item ToDo(this ItemDbo dbo) =>
        new Item
        {
            Id = dbo.Id,
            Name = dbo.Name,
            Description = dbo.Description
        };

    public static ItemDbo ToDbo(this Item domain) =>
        new ItemDbo
        {
            Id = domain.Id,
            Name = domain.Name,
            Description = domain.Description
        };

    public static void UpdateDbo(this ItemDbo dbo, Item item)
    {
        dbo.Name = item.Name;
        dbo.Description = item.Description;
    }

}

