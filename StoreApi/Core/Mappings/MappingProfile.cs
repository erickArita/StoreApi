using AutoMapper;
using StoreApi.Core.Customers.Requests;
using StoreApi.Core.Customers.Responses;
using StoreApi.Domain.Customers;

namespace StoreApi.Core.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerRequest, Customer>();
        CreateMap<UpdateCustomerRequest, Customer>();
        CreateMap<Customer, CustomerResponse>();
    }
}