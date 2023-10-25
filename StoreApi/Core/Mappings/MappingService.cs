namespace StoreApi.Core.Mappings;

public static class MappingService
{
    public static IServiceCollection AddMappingService(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}