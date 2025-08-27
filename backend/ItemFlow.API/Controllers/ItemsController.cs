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

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ItemDto>> GetItemById(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            Item item = await itemService.GetItemByIdAsync(id, cancellationToken);
            return Ok(item.ToDto());
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult<ItemDto>> CreateItem([FromBody] CreateItemDto createDto, CancellationToken cancellationToken = default)
    {
        Item item = createDto.ToDo();

        Item savedItem = await itemService.CreateItemAsync(item, cancellationToken);

        ItemDto itemDto = savedItem.ToDto();

        return CreatedAtAction(nameof(GetItemById), new { id = itemDto.Id }, itemDto);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ItemDto>> UpdateItem(Guid id, [FromBody] UpdateItemDto updateDto, CancellationToken cancellationToken = default)
    {
        try
        {
            Item item = updateDto.ToDo(id);
            Item updated = await itemService.UpdateItemAsync(item, cancellationToken);
            return Ok(updated.ToDto());
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteItem(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            await itemService.DeleteItemAsync(id, cancellationToken);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
