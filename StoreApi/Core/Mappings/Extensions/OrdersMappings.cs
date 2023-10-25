using StoreApi.Core.Orders.Requests;
using StoreApi.Core.Orders.Responses;
using StoreApi.Domain.Orders;

namespace StoreApi.Core.Mappings.Extensions;

public static class OrdersMappings
{
    public static void AddOrdersMappings(this MappingProfile _)
    {
        _.CreateMap<CreateOrderRequest, Order>();
        _.CreateMap<Order, OrderResponse>();
        _.CreateMap<UpdateOrderRequest, Order>();
    }
}