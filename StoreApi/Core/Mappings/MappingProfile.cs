using AutoMapper;
using StoreApi.Core.Mappings.Extensions;

namespace StoreApi.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.AddCustomersMappings();
        this.AddOrdersMappings();
        this.AddProductsMappings();
    }
}