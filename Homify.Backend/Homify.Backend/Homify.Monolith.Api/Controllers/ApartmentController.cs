using Homify.Monolith.Application.Common.Results;
using Homify.Monolith.Application.Dtos.Apartment;
using Homify.Monolith.Application.Services.ApartmentService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc; 

namespace Homify.Monolith.Api.Controllers;

[ApiController]
[Route("api/apartments")]
public class ApartmentController(IApartmentService apartmentService): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllApartments()
    {
        var result =  await apartmentService.GetAllApartmentsAsync();

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddApartment([FromBody] ApartmentDto apartmentDto)
    {
        var result =  await apartmentService.AddApartmentAsync(apartmentDto);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
}