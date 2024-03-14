using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;
using OnlineShop.Services.Services;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;

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

        [HttpPost]
        public async Task<ActionResult<AddressInformationDTO>> CreateAddress([FromBody] SaveAddressInformationDTO saveAddressInformationResource)
        {
            var validator = new SaveAddressInformationResourceValidator();

            var validationResult = await validator.ValidateAsync(saveAddressInformationResource);

            if (validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors);

            var addressToCreate = _mapper.Map<SaveAddressInformationDTO, AddressInformation>(saveAddressInformationResource);

            var newAddressInformation = await _addressInformationService.CreateAddress(addressToCreate);

            var address = await _addressInformationService.GetAddressInformationById(newAddressInformation.AddressID);

            var addressResource = _mapper.Map< AddressInformation, AddressInformationDTO>(address);

            return Ok(addressResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressInformationDTO>> UpdateAddress(int id, [FromBody] SaveAddressInformationDTO saveAddressInformationResource)
        {
            var validator = new SaveAddressInformationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAddressInformationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var addressToUpdate = await _addressInformationService.GetAddressInformationById(id);

            if (addressToUpdate == null)
                return NotFound();

            _mapper.Map(saveAddressInformationResource, addressToUpdate);

            var updatedAddress = _mapper.Map<SaveAddressInformationDTO, AddressInformation>(saveAddressInformationResource);
            
            await _addressInformationService.UpdateAddress(addressToUpdate, updatedAddress);

            var updatedAddressInformation = await _addressInformationService.GetAddressInformationById(id);

            var addressResource = _mapper.Map<AddressInformation, AddressInformationDTO>(updatedAddressInformation);

            return Ok(addressResource);
        }
    }
}
