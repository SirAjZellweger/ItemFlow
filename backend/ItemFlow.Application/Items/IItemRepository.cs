using ItemFlow.Domain.Items;

namespace ItemFlow.Application.Items;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Item> AddAsync(Item item, CancellationToken cancellationToken = default);
    Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Item> UpdateAsync(Item item, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
