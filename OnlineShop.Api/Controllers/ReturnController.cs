using Microsoft.AspNetCore.Mvc;
using OnlineShop.Core.Models.OrderManagement;
using OnlineShop.Core.Services;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnController : ControllerBase
    {
        private readonly IReturnService _returnService;
        public ReturnController(IReturnService returnService)
        {
            this. _returnService = returnService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Return>>> GetAllReturn()
        {
            var returns = await _returnService.GetAllReturn();
            return Ok(returns);
        }
    }
}
