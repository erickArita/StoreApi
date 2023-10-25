using Microsoft.EntityFrameworkCore;
using StoreApi.Infrastructure.Persistence;


namespace StoreApi.Infrastructure;

public static class InfrastructureServicesExtension
{
    public static IServiceCollection AddInfrastructureServicesExtension(this IServiceCollection services,
        IConfiguration configuration, IWebHostEnvironment env)
    {
        var isDevelopment = env.IsDevelopment();
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        var customerConnection = configuration.GetConnectionString("CustomerConnection");
        var orderConnection = configuration.GetConnectionString("OrderConnection");

        services.AddDbContext<CustomerDbContext>(opts =>
        {
            opts.UseSqlServer(customerConnection);
            opts.EnableServiceProviderCaching(false); //para que no se guarde en cache la conexion 
        });
        services.AddDbContext<OrderDbContext>(opts =>
        {
            opts.UseSqlServer(orderConnection);
            opts.EnableServiceProviderCaching(false);
        });

        // correr automaticamente las mgraciones si se esta en desarrollo
        if (isDevelopment)
        {
            services.BuildServiceProvider().GetService<CustomerDbContext>().Database.Migrate();
            services.BuildServiceProvider().GetService<OrderDbContext>().Database.Migrate();
        }

        return services;
    }
}