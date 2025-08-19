using ItemFlow.Application.Items;
using ItemFlow.Domain.Items;
using ItemFlow.Infrastructure.Mappers;

using Microsoft.EntityFrameworkCore;

namespace ItemFlow.Infrastructure.Repositories;

public class ItemRepository(AppDbContext context) : IItemRepository
{
    public async Task<Item> AddAsync(Item item, CancellationToken cancellationToken = default)
    {
        context.Items.Add(item.ToDbo());
        await context.SaveChangesAsync(cancellationToken);

        return item;
    }

    public async Task<IEnumerable<Item>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Items
            .AsNoTracking()
            .Select(dbo => dbo.ToDo())
            .ToListAsync(cancellationToken);
    }
}
