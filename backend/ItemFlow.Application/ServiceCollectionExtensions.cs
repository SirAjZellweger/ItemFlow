using ItemFlow.Application.Items;

using Microsoft.Extensions.DependencyInjection;

namespace ItemFlow.Application;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IItemService, ItemService>();
        return services;
    }
}
