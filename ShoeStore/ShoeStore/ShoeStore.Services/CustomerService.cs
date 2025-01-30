using ShoeStore.Core.Models;
using ShoeStore.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeStore.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomersAsync() => await _customerRepository.GetAllAsync();
        public async Task<Customer> GetCustomerByIdAsync(string id) => await _customerRepository.GetByIdAsync(id);
        public async Task CreateCustomerAsync(Customer customer) => await _customerRepository.CreateAsync(customer);
        public async Task UpdateCustomerAsync(string id, Customer customer) => await _customerRepository.UpdateAsync(id, customer);
        public async Task DeleteCustomerAsync(string id) => await _customerRepository.DeleteAsync(id);
    }
}   