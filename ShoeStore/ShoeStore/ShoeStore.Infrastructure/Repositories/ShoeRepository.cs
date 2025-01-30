using MongoDB.Driver;
using ShoeStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeStore.Infrastructure.Repositories
{
    public class ShoeRepository
    {
        private readonly IMongoCollection<Shoe> _shoes;

        public ShoeRepository(IMongoDatabase database)
        {
            _shoes = database.GetCollection<Shoe>("Shoes");
        }

        public async Task<List<Shoe>> GetAllAsync() => await _shoes.Find(_ => true).ToListAsync();
        public async Task<Shoe> GetByIdAsync(string id) => await _shoes.Find(s => s.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Shoe shoe) => await _shoes.InsertOneAsync(shoe);
        public async Task UpdateAsync(string id, Shoe shoe) => await _shoes.ReplaceOneAsync(s => s.Id == id, shoe);
        public async Task DeleteAsync(string id) => await _shoes.DeleteOneAsync(s => s.Id == id);
    }
}