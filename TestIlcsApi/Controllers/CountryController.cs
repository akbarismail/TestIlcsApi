using Microsoft.AspNetCore.Mvc;
using TestIlcsApi.Entities;
using TestIlcsApi.Services;

namespace TestIlcsApi.Controllers;

[ApiController]
[Route("insw-dev.ilcs.co.id/n/negara")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNewCountry([FromBody] Country payload)
    {
        try
        {
            var country = await _countryService.Create(payload);
            return Created("/insw-dev.ilcs.co.id/n/negara", country);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetIdCountry(string id)
    {
        try
        {
            var country = await _countryService.GetById(id);
            return Ok(country);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetMyCountry([FromQuery] string urNegara)
    {
        try
        {
            var country = await _countryService.GetBy(country => 
                country.Char != null && country.Char.Equals(urNegara));
            return Ok(country);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCountry([FromBody] Country payload)
    {
        try
        {
            var country = await _countryService.Update(payload);
            return Ok(country);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }
}