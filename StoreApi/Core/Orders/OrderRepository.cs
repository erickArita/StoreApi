using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApi.Core.Orders.Requests;
using StoreApi.Core.Orders.Responses;
using StoreApi.Domain.Orders;
using StoreApi.Infrastructure.Persistence;

namespace StoreApi.Core.Orders;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _orderDbContext;
    private readonly CustomerDbContext _customerContext;
    private readonly IMapper _mapper;

    public OrderRepository(CustomerDbContext customerContext, OrderDbContext orderDbContext, IMapper mapper)
    {
        _orderDbContext = orderDbContext;
        _customerContext = customerContext;
        _mapper = mapper;
    }

    public async Task<OrderResponse> AddOrderAsync(CreateOrderRequest order)
    {
        var customer = await _customerContext.Customers.Where(c => c.Id == order.CustomerId).FirstOrDefaultAsync();

        if (customer == null)
        {
            throw new Exception("Cliente no encontrado");
        }

        var newOrder = _mapper.Map<Order>(order);
        newOrder.Id = Guid.NewGuid();
        newOrder.CustomerId = customer.Id;
        var products = _mapper.Map<List<OrderProduct>>(order.OrderProducts, opt => opt.Items["OrderId"] = newOrder.Id);

        newOrder.OrderProducts = products;

        await _orderDbContext.Orders.AddAsync(newOrder);
        await _orderDbContext.SaveChangesAsync();

        return _mapper.Map<OrderResponse>(newOrder);
    }

    public async Task<IEnumerable<OrderResponse>> GetOrdersAsync()
    {
        var orders = await _orderDbContext.Orders.ToListAsync();
        return _mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public async Task<OrderResponse> GetOrderAsync(Guid orderId)
    {
        var order = await _orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
        if (order is null)
        {
            throw new Exception("Orden no encontrada");
        }

        return _mapper.Map<OrderResponse>(order);
    }

    public async Task<IEnumerable<OrderResponse>> GetOrdersByCustomerAsync(Guid customerId)
    {
        var customer = await _customerContext.Customers.Where(c => c.Id == customerId).FirstOrDefaultAsync();

        if (customer is null)
        {
            throw new Exception("Cliente no encontrado");
        }

        var orders = await _orderDbContext.Orders.Where(o => o.CustomerId == customer.Id).ToListAsync();
        return _mapper.Map<IEnumerable<OrderResponse>>(orders);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        var order = await _orderDbContext.Orders.Where(o => o.Id == orderId).FirstOrDefaultAsync();
        if (order is null)
        {
            throw new Exception("Orden no encontrada");
        }

        _orderDbContext.Orders.Remove(order);
        await _orderDbContext.SaveChangesAsync();
    }

    public async Task<OrderResponse> UpdateOrderAsync(UpdateOrderRequest order)
    {
        var orderToUpdate = await _orderDbContext.Orders.Where(o => o.Id == order.Id).FirstOrDefaultAsync();
        if (orderToUpdate is null)
        {
            throw new Exception("Orden no encontrada");
        }

        var orderUpdated = _mapper.Map(order, orderToUpdate);

        _orderDbContext.Orders.Update(orderUpdated);

        await _orderDbContext.SaveChangesAsync();

        return _mapper.Map<OrderResponse>(orderUpdated);
    }
}