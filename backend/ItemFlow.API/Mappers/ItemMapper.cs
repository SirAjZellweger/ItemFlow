using ItemFlow.API.Dtos;
using ItemFlow.Domain.Items;

namespace ItemFlow.API.Mappers;

public static class ItemMapper
{
    public static ItemDto ToDto(this Item item)
    {
        return new(item.Id, item.Name, item.Description);
    }

    public static Item ToDo(this CreateItemDto dto)
    {
        return Item.Create(dto.Name, dto.Description);
    }

    public static Item ToDo(this UpdateItemDto dto, Guid id)
    {
        return new()
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description
        };
    }
}

