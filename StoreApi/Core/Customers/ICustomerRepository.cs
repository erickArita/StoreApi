﻿using StoreApi.Core.Customers.Requests;
using StoreApi.Core.Customers.Responses;
using StoreApi.Domain.Customers;

namespace StoreApi.Core.Customers;

public interface ICustomerRepository
{
    Task<Guid> CreateCustomerAsync(CreateCustomerRequest request);
    Task<CustomerResponse> GetCustomerAsync(Guid id);
    Task DeleteCustomerAsync(Guid id);
    Task<CustomerResponse> UpdateCustomerAsync(UpdateCustomerRequest request);
    Task<IEnumerable<CustomerResponse>> GetCustomersAsync();
}