using StoreApi.Core.Products.Requests;
using StoreApi.Core.Products.Responses;

namespace StoreApi.Core.Products;

public interface IProductRepository
{
    Task<ProductResponse> CreateProductAsync(CreateProductRequest request);
    Task<ProductResponse> GetProductByIdAsync(Guid id);
    Task<IEnumerable<ProductResponse>> GetProductsAsync();
    Task<ProductResponse> UpdateProductAsync(Guid id, UpdateProductRequest request);
    Task DeleteProductAsync(Guid id);
}