using ItemFlow.Domain.Items;
using ItemFlow.Infrastructure.DBOs;

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
}

