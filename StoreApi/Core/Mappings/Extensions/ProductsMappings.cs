using StoreApi.Core.Products.Requests;
using StoreApi.Core.Products.Responses;
using StoreApi.Domain.Orders;

namespace StoreApi.Core.Mappings.Extensions;

public static class ProductsMappings
{
    public static void AddProductsMappings(this MappingProfile _)
    {
        _.CreateMap<CreateProductRequest, Product>();
        _.CreateMap<Product, ProductResponse>();
        _.CreateMap<UpdateProductRequest, Product>();
    }
}