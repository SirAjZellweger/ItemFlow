using ItemFlow.API.Dtos;
using ItemFlow.API.Mappers;
using ItemFlow.Application.Items;
using ItemFlow.Domain.Items;

using Microsoft.AspNetCore.Mvc;

namespace ItemFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController(IItemService itemService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems(CancellationToken cancellationToken = default)
    {
        IEnumerable<Item> items = await itemService.GetAllItemsAsync(cancellationToken);

        return Ok(items.Select(i => i.ToDto()));
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItem([FromBody] CreateItemDto createDto, CancellationToken cancellationToken = default)
    {
        Item item = createDto.ToDo();

        Item savedItem = await itemService.CreateItemAsync(item, cancellationToken);

        ItemDto itemDto = savedItem.ToDto();

        // TODO: Der erste parameter der CreatedAtAction-Methode sollte der Name der Action sein, die den neuen Eintrag zurückgibt (GetItemById).
        return CreatedAtAction(nameof(CreateItem), new { id = itemDto.Id }, itemDto);
    }
}
