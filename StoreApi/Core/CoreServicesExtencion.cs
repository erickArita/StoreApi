using StoreApi.Core.Customers;

namespace StoreApi.Core;

public static class CoreServicesExtencion
{
    public static IServiceCollection AddCoreServicesExtencion(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddScoped<ICustomerRepository,CustomerRepository>();
        return services;
    }
}