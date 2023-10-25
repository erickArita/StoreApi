using StoreApi.Core.Orders.Requests;
using StoreApi.Core.Orders.Responses;

namespace StoreApi.Core.Orders;

public interface IOrderRepository
{
    Task<OrderResponse> AddOrderAsync(CreateOrderRequest order);
    Task<IEnumerable<OrderResponse>> GetOrdersAsync();
    Task<OrderResponse> GetOrderAsync(Guid orderId);
    Task<IEnumerable<OrderResponse>> GetOrdersByCustomerAsync(Guid customerId);
    Task DeleteOrderAsync(Guid orderId);
    Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest order);
}