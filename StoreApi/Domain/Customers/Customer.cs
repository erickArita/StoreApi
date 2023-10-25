using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreApi.Domain.Orders;

namespace StoreApi.Domain.Customers;

[Table("customers")]
public class Customer
{
    public Guid Id { get; set; }

    [Required] public string FirstName { get; set; }

    [Required] public string LastName { get; set; }

    [EmailAddress] public string Email { get; set; }

    [DataType(DataType.Date)] public DateTime BirthDate { get; set; }

    [StringLength(100, MinimumLength = 5)] public string Address { get; set; }

    [Phone] public string PhoneNumber { get; set; }

    public List<Order> Orders { get; set; } = new();
}