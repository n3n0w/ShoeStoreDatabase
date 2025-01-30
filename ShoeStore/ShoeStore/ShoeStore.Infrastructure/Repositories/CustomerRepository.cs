using MongoDB.Driver;
using ShoeStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeStore.Infrastructure.Repositories
{
    public class CustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(IMongoDatabase database)
        {
            _customers = database.GetCollection<Customer>("Customers");
        }

        public async Task<List<Customer>> GetAllAsync() => await _customers.Find(_ => true).ToListAsync();
        public async Task<Customer> GetByIdAsync(string id) => await _customers.Find(c => c.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Customer customer) => await _customers.InsertOneAsync(customer);
        public async Task UpdateAsync(string id, Customer customer) => await _customers.ReplaceOneAsync(c => c.Id == id, customer);
        public async Task DeleteAsync(string id) => await _customers.DeleteOneAsync(c => c.Id == id);
    }
}