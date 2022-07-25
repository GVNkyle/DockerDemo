using API._Services.Interface;
using API.DTO;
using API.Helpers.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AddressController : ApiController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("SearchData")]
        public async Task<IActionResult> SearchData([FromQuery] PaginationParam pagination)
        {
            return Ok(await _addressService.SearchData(pagination));
        }

        [HttpPost("AddNewAddress")]
        public async Task<IActionResult> AddNewAddress([FromBody] AddressDTO address)
        {
            return Ok(await _addressService.AddNewAddress(address));
        }

        [HttpPut("UpdateAddress")]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressDTO address)
        {
            return Ok(await _addressService.UpdateAddress(address));
        }

        [HttpDelete("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress([FromQuery] int addressID)
        {
            return Ok(await _addressService.DeleteAddress(addressID));
        }
    }
}