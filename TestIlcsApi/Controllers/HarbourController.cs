using Microsoft.AspNetCore.Mvc;
using TestIlcsApi.Entities;
using TestIlcsApi.Services;

namespace TestIlcsApi.Controllers;

[ApiController]
[Route("insw-dev.ilcs.co.id/n/pelabuhan")]
public class HarbourController : ControllerBase
{
    private readonly IHarbourService _harbourService;

    public HarbourController(IHarbourService harbourService)
    {
        _harbourService = harbourService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewHarbour([FromBody] Harbour payload)
    {
        try
        {
            var harbour = await _harbourService.Create(payload);
            return Created("/insw-dev.ilcs.co.id/n/pelabuhan", harbour);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetBy([FromQuery] string kdNegara, [FromQuery] string urPelabuhan)
    {
        try
        {
            var harbour = await _harbourService.GetBy(harbour => 
                harbour.Country != null && harbour.Char != null && harbour.Country.Code != null && 
                harbour.Char.Equals(urPelabuhan) && harbour.Country.Code.Equals(kdNegara), new []
            {
                "Country"
            }) ;
            return Ok(harbour);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }
}