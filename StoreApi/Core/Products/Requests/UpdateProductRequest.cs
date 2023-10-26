using Microsoft.Build.Framework;

namespace StoreApi.Core.Products.Requests;

public class UpdateProductRequest
{
    [Required] public string Name { get; set; }
    [Required] public decimal Price { get; set; }
}