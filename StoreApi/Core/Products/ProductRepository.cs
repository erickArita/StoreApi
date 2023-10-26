using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApi.Core.Products.Requests;
using StoreApi.Core.Products.Responses;
using StoreApi.Domain.Orders;
using StoreApi.Infrastructure.Persistence;

namespace StoreApi.Core.Products;

public class ProductRepository : IProductRepository
{
    private readonly OrderDbContext _orderDbContext;
    private readonly IMapper _mapper;

    public ProductRepository(OrderDbContext orderDbContext, IMapper mapper)
    {
        _orderDbContext = orderDbContext;
        _mapper = mapper;
    }

    public async Task<ProductResponse> CreateProductAsync(CreateProductRequest request)
    {
        var newProduct = _mapper.Map<Product>(request);
        newProduct.Id = Guid.NewGuid();
        await _orderDbContext.Products.AddAsync(newProduct);
        await _orderDbContext.SaveChangesAsync();

        return _mapper.Map<ProductResponse>(newProduct);
    }

    public async Task<ProductResponse> GetProductByIdAsync(Guid id)
    {
        var product = await _orderDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        if (product == null)
        {
            throw new Exception($"El producto con el id {id} no existe");
        }

        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync()
    {
        var products = await _orderDbContext.Products.ToListAsync();
        return _mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<ProductResponse> UpdateProductAsync(Guid id, UpdateProductRequest request)
    {
        var product = await _orderDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        if (product == null)
        {
            throw new Exception($"El producto con el id {id} no existe");
        }

        var updatedProduct = _mapper.Map(request, product);
        _orderDbContext.Products.Update(updatedProduct);
        await _orderDbContext.SaveChangesAsync();

        return _mapper.Map<ProductResponse>(product);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await _orderDbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        if (product == null)
        {
            throw new Exception($"El producto con el id {id} no existe");
        }

        _orderDbContext.Products.Remove(product);
        await _orderDbContext.SaveChangesAsync();
    }
}