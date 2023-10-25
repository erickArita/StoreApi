using Microsoft.AspNetCore.Mvc;
using StoreApi.Core.Orders;
using StoreApi.Core.Orders.Requests;
using StoreApi.Core.Orders.Responses;

namespace StoreApi.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{CustomerId:guid}")]
        public async Task<IEnumerable<OrderResponse>> GetOrdersByCustomer(Guid CustomerId)
        {
            var orders = await _orderRepository.GetOrdersByCustomerAsync(CustomerId);
            return orders;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResponse>> Get()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return orders;
        }

        // GET: api/Order/5
        [HttpGet("{id:guid}")]
        public async Task<OrderResponse> Get(Guid id)
        {
            return await _orderRepository.GetOrderAsync(id);
        }

        // POST: api/Order
        [HttpPost]
        public async Task<OrderResponse> Post([FromBody] CreateOrderRequest value)
        {
            return await _orderRepository.AddOrderAsync(value);
        }

        // PUT: api/Order/5
        [HttpPut("{id:guid}")]
        public async Task<OrderResponse> Put(Guid id, [FromBody] UpdateOrderRequest value)
        {
            return await _orderRepository.UpdateOrderAsync(value);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id:guid}")]
        public async void Delete(Guid id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}