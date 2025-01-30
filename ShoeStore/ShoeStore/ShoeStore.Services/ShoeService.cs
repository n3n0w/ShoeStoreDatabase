using ShoeStore.Core.Models;
using ShoeStore.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeStore.Services
{
    public class ShoeService
    {
        private readonly ShoeRepository _shoeRepository;

        public ShoeService(ShoeRepository shoeRepository)
        {
            _shoeRepository = shoeRepository;
        }

        public async Task<List<Shoe>> GetAllShoesAsync() => await _shoeRepository.GetAllAsync();
        public async Task<Shoe> GetShoeByIdAsync(string id) => await _shoeRepository.GetByIdAsync(id);
        public async Task CreateShoeAsync(Shoe shoe) => await _shoeRepository.CreateAsync(shoe);
        public async Task UpdateShoeAsync(string id, Shoe shoe) => await _shoeRepository.UpdateAsync(id, shoe);
        public async Task DeleteShoeAsync(string id) => await _shoeRepository.DeleteAsync(id);
    }
}