namespace StoreApi.Core.Orders.Requests;

public class UpdateOrderRequest
{
    public Guid Id { get; set; }
    public string ShippingAddress { get; set; }
    public List<OrderProductRequest> OrderProducts { get; set; } = new();
}