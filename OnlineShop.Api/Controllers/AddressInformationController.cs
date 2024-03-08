using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;
using OnlineShop.Api.DTO;

namespace OnlineShop.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressInformationController : ControllerBase
    {
        private readonly IAddressInformationService _addressInformationService;
        private readonly IMapper _mapper;
        public AddressInformationController(IAddressInformationService addressInformationService, IMapper mapper)
        {
            this._addressInformationService = addressInformationService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressInformation>>> GetAllAddressInformation()
        {
            var addressInformations = await _addressInformationService.GetAllAddressInformation();

            var addressInformationResources = _mapper.Map<IEnumerable<AddressInformation>,IEnumerable<AddressInformationDTO>>(addressInformations);
            return Ok(addressInformationResources);
        }
    }
}
