using Microsoft.AspNetCore.Mvc;
using StoreApi.Core.Customers;
using StoreApi.Core.Customers.Requests;
using StoreApi.Core.Customers.Responses;

namespace StoreApi.Web
{
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
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<Guid> Post([FromBody] CreateCustomerRequest value)
        {
            return await _customerRepository.CreateCustomerAsync(value);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}