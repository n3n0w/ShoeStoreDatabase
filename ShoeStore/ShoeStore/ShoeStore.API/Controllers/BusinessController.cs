using Microsoft.AspNetCore.Mvc;
using ShoeStore.Services;
using System.Threading.Tasks;

namespace ShoeStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly BusinessService _businessService;

        public BusinessController(BusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet("total-shoes")]
        public async Task<IActionResult> GetTotalShoes()
        {
            var totalShoes = await _businessService.GetTotalShoesAsync();
            return Ok(totalShoes);
        }

        [HttpGet("total-customers")]
        public async Task<IActionResult> GetTotalCustomers()
        {
            var totalCustomers = await _businessService.GetTotalCustomersAsync();
            return Ok(totalCustomers);
        }
    }
}