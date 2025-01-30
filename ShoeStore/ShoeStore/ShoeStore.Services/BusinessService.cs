using ShoeStore.Core.Models;
using System.Threading.Tasks;

namespace ShoeStore.Services
{
    public class BusinessService
    {
        private readonly ShoeService _shoeService;
        private readonly CustomerService _customerService;

        public BusinessService(ShoeService shoeService, CustomerService customerService)
        {
            _shoeService = shoeService;
            _customerService = customerService;
        }

        public async Task<int> GetTotalShoesAsync() => (await _shoeService.GetAllShoesAsync()).Count;
        public async Task<int> GetTotalCustomersAsync() => (await _customerService.GetAllCustomersAsync()).Count;
    }
}