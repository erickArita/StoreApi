namespace StoreApi.Core.Orders.Responses;

public class OrderResponse
{
    public Guid Id { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string ShippingAddress { get; set; }

    public IEnumerable<OrderProductResponse> OrderProducts { get; set; }

    public int CustomerId { get; set; }
}