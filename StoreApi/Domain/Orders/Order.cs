using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreApi.Domain.Customers;

namespace StoreApi.Domain.Orders;

[Table("orders")]
public class Order
{
    public Guid Id { get; set; }

    [Required] public DateTime OrderDate { get; set; }

    [Range(0.01, double.MaxValue)] public decimal TotalAmount { get; set; }

    [Required] public string ShippingAddress { get; set; }

    public List<OrderProduct> OrderProducts { get; set; } = new();

    [Required]
    [ForeignKey(nameof(Customer))]
    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }
}