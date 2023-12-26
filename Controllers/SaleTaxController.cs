using Microsoft.AspNetCore.Mvc;
using SalesTax.Dto;
using SalesTax.Model;
using SalesTax.Service.Interface;

namespace SalesTax.Controllers
{
    [Route("api/sale")]
    [ApiController]
    public class SaleTaxController : ControllerBase
    {
        private readonly ISaleTaxService _saleTaxService;

        public SaleTaxController(ISaleTaxService saleTaxService)
        {
            _saleTaxService = saleTaxService;
        }
        [HttpPost("tax")]
        public IActionResult SaleTaxReceiptAsync(List<ItemsDto> items)
        {
            var response = _saleTaxService.GenerateReceipt(items);
            if (response.StatusCode == 200)
            {
                return Ok(response);
            }
            else if (response.StatusCode == 404)
            {
                return NotFound(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
