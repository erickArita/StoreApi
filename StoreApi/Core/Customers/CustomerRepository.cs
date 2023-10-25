using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreApi.Core.Customers.Requests;
using StoreApi.Core.Customers.Responses;
using StoreApi.Domain.Customers;
using StoreApi.Infrastructure.Persistence;

namespace StoreApi.Core.Customers;

public class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _customerContext;
    private readonly IMapper _mapper;

    public CustomerRepository(CustomerDbContext customerContext, IMapper mapper)
    {
        _customerContext = customerContext;
        _mapper = mapper;
    }

    public async Task<Guid> CreateCustomerAsync(CreateCustomerRequest request)
    {
        var customer = _mapper.Map<Customer>(request);
        customer.Id = Guid.NewGuid();
        await _customerContext.Customers.AddAsync(customer);
        await _customerContext.SaveChangesAsync();

        return customer.Id;
    }

    public async Task<CustomerResponse> GetCustomerAsync(Guid id)
    {
        var customer = await _customerContext.Customers.Where(c => c.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<CustomerResponse>(customer);
    }

    public async Task<IEnumerable<CustomerResponse>> GetCustomersAsync()
    {
        var customers = await _customerContext.Customers.ToListAsync();
        return _mapper.Map<IEnumerable<CustomerResponse>>(customers);
    }
}