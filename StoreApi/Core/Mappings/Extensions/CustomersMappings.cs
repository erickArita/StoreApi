using StoreApi.Core.Customers.Requests;
using StoreApi.Core.Customers.Responses;
using StoreApi.Domain.Customers;

namespace StoreApi.Core.Mappings.Extensions;

public static class CustomersMappings
{
    public static void AddCustomersMappings(this MappingProfile _)
    {
        _.CreateMap<CreateCustomerRequest, Customer>();
        _.CreateMap<UpdateCustomerRequest, Customer>();
        _.CreateMap<Customer, CustomerResponse>();
    }
}