using StoreApi.Core.Customers;
using StoreApi.Core.Orders;

namespace StoreApi.Core;

public static class CoreServicesExtencion
{
    public static IServiceCollection AddCoreServicesExtencion(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}