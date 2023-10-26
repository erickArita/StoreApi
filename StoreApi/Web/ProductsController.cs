using Microsoft.AspNetCore.Mvc;
using StoreApi.Core.Products;
using StoreApi.Core.Products.Requests;
using StoreApi.Core.Products.Responses;

namespace StoreApi.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductResponse>> Get()
        {
            var products = await _productRepository.GetProductsAsync();
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ProductResponse> Get(Guid id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ProductResponse> Post([FromBody] CreateProductRequest request)
        {
            return await _productRepository.CreateProductAsync(request);
        }

        [HttpPut("{id}")]
        public async Task<ProductResponse> Put(Guid id, [FromBody] UpdateProductRequest value)
        {
            return await _productRepository.UpdateProductAsync(id, value);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    }
}