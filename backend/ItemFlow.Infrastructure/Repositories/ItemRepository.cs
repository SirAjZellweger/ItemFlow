using ItemFlow.Application.Items;
using ItemFlow.Domain.Items;
using ItemFlow.Infrastructure.Dbos;
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

    public async Task<Item> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        ItemDbo? dbo = await context.Items
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken)
                ?? throw new KeyNotFoundException($"Item mit Id {id} nicht gefunden.");

        return dbo.ToDo();
    }

    public async Task<Item> UpdateAsync(Item item, CancellationToken cancellationToken = default)
    {
        ItemDbo? dbo = await context.Items.FindAsync(item.Id, cancellationToken)
            ?? throw new KeyNotFoundException($"Item mit Id {item.Id} nicht gefunden.");

        dbo.UpdateDbo(item);

        context.Items.Update(dbo);
        await context.SaveChangesAsync(cancellationToken);

        return item;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        ItemDbo? dbo = await context.Items.FindAsync(id, cancellationToken)
            ?? throw new KeyNotFoundException($"Item mit Id {id} nicht gefunden.");

        context.Items.Remove(dbo);
        await context.SaveChangesAsync(cancellationToken);
    }
}
