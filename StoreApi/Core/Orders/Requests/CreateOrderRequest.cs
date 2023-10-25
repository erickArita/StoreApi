using System.ComponentModel.DataAnnotations;

namespace StoreApi.Core.Orders.Requests;

public class CreateOrderRequest
{
    [Required] public string ShippingAddress { get; set; }

    public List<OrderProductRequest> OrderProducts { get; set; } = new();

    [Required] public Guid CustomerId { get; set; }
}