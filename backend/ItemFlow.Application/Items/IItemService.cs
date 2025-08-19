using ItemFlow.Domain.Items;

namespace ItemFlow.Application.Items;

public interface IItemService
{
    Task<IEnumerable<Item>> GetAllItemsAsync(CancellationToken cancellationToken = default);
    Task<Item> CreateItemAsync(Item item, CancellationToken cancellationToken = default);
}
