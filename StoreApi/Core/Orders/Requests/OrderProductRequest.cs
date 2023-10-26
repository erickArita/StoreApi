using Microsoft.Build.Framework;

namespace StoreApi.Core.Orders.Requests;

public class OrderProductRequest
{
    [Required] public int ProductId { get; set; }
    [Required] public int Quantity { get; set; }
}