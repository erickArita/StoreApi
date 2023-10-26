using System.ComponentModel.DataAnnotations;

namespace StoreApi.Domain.Orders;

public class Product
{
    public Guid Id { get; set; }
    [Required] public string Name { get; set; }
    [Required] public decimal Price { get; set; }

    public List<OrderProduct> OrderProducts { get; set; }
}