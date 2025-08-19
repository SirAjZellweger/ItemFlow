using ItemFlow.API.Dtos;
using ItemFlow.Domain.Items;

namespace ItemFlow.API.Mappers;

public static class ItemMapper
{
    public static ItemDto ToDto(this Item item) =>
        new(item.Id, item.Name, item.Description);

    public static Item ToDo(this CreateItemDto dto) =>
        Item.Create(dto.Name, dto.Description);
}

