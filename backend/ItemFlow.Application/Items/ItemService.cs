using ItemFlow.Domain.Items;

namespace ItemFlow.Application.Items;
public class ItemService(IItemRepository repository) : IItemService
{
    public async Task<Item> CreateItemAsync(Item item, CancellationToken cancellationToken = default)
    {
        return await repository.AddAsync(item, cancellationToken);
    }

    public async Task<IEnumerable<Item>> GetAllItemsAsync(CancellationToken cancellationToken = default)
    {
        return await repository.GetAllAsync(cancellationToken);
    }
}
