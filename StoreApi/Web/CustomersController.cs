using Microsoft.AspNetCore.Mvc;
using StoreApi.Core.Customers;
using StoreApi.Core.Customers.Requests;
using StoreApi.Core.Customers.Responses;

namespace StoreApi.Web;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    // GET: api/Customers
    [HttpGet]
    public async Task<IEnumerable<CustomerResponse>> Get()
    {
        return await _customerRepository.GetCustomersAsync();
    }

    // GET: api/Customers/5
    [HttpGet("{id:guid}")]
    public async Task<CustomerResponse> Get(Guid id)
    {
        return await _customerRepository.GetCustomerAsync(id);
    }

    // POST: api/Customers
    [HttpPost]
    public async Task<Guid> Post([FromBody] CreateCustomerRequest value)
    {
        return await _customerRepository.CreateCustomerAsync(value);
    }

    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public async Task<CustomerResponse> Put(Guid id, [FromBody] UpdateCustomerRequest value)
    {
        value.Id = id;
        return await _customerRepository.UpdateCustomerAsync(value);
    }

    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task Delete(Guid id)
    {
        await _customerRepository.DeleteCustomerAsync(id);
    }
}