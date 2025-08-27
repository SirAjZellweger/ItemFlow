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

    public async Task<Item> GetItemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await repository.GetByIdAsync(id, cancellationToken);
    }


    public async Task<Item> UpdateItemAsync(Item item, CancellationToken cancellationToken = default)
    {
        return await repository.UpdateAsync(item, cancellationToken);
    }

    public async Task DeleteItemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        await repository.DeleteAsync(id, cancellationToken);
    }
}
