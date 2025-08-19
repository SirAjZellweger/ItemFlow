using ItemFlow.Domain.Items;

namespace ItemFlow.Application.Items;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Item> AddAsync(Item item, CancellationToken cancellationToken = default);
}
