using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Domain.Orders;

public class OrderProduct
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey(nameof(Order))] [Required] public Guid OrderId { get; set; }

    public Order Order { get; set; }

    [ForeignKey(nameof(Product))]
    [Required]
    public Guid ProductId { get; set; }

    public Product Product { get; set; }
    [Required] public int Quantity { get; set; }
}