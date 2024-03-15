using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using OnlineShop.Core.Models.CustomerManagement;
using OnlineShop.Core.Services;
using OnlineShop.Api.DTO;
using OnlineShop.Api.Validators;

namespace OnlineShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<AddressInformationDTO>>> GetAllAddressInformation()
        {
            var addressInformations = await _addressInformationService.GetAllAddressInformation();

            var addressInformationResources = _mapper.Map<IEnumerable<AddressInformation>,IEnumerable<AddressInformationDTO>>(addressInformations);
            return Ok(addressInformationResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressInformationDTO>> GetAddressInformationById (int id)
        {
            var addressInformation = await _addressInformationService.GetAddressInformationById(id);
            var addressInformationResource = _mapper.Map<AddressInformation, AddressInformationDTO>(addressInformation);

            return Ok(addressInformationResource);         
        }

        [HttpPost("")]
        public async Task<ActionResult<AddressInformationDTO>> CreateAddress([FromBody] SaveAddressInformationDTO saveAddressInformationResource)
        {
            var validator = new SaveAddressInformationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveAddressInformationResource);

            if (!validationResult.IsValid) //doğrulama sonucunu kotnrol eder
                return BadRequest(validationResult.Errors);

            var addressToCreate = _mapper.Map<SaveAddressInformationDTO, AddressInformation>(saveAddressInformationResource);
            var newAddressInformation = await _addressInformationService.CreateAddress(addressToCreate);
            var addressResource = _mapper.Map< AddressInformation, AddressInformationDTO>(newAddressInformation);

            return CreatedAtAction(nameof(GetAddressInformationById), new { id = addressResource.AddressID }, addressResource);
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

            var addressInformation = _mapper.Map<SaveAddressInformationDTO, AddressInformation>(saveAddressInformationResource);

            await _addressInformationService.UpdateAddress(addressToUpdate, addressInformation);

            var updatedAddressInformation = await _addressInformationService.GetAddressInformationById(id);

            if (updatedAddressInformation == null)
                return NotFound();

            var updatedAddressInformationResource = _mapper.Map<AddressInformation, AddressInformationDTO> (updatedAddressInformation);

            return Ok(updatedAddressInformationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (id == 0)
                return BadRequest();

            var addressInformation = await _addressInformationService.GetAddressInformationById(id);

            if (addressInformation == null)
                return NotFound();

            await _addressInformationService.DeleteAddress(addressInformation);

            return NoContent();
        }
    }
}
