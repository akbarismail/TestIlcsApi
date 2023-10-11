using Microsoft.AspNetCore.Mvc;
using TestIlcsApi.Entities;
using TestIlcsApi.Services;

namespace TestIlcsApi.Controllers;

[ApiController]
[Route("insw-dev.ilcs.co.id/n/tarif")]
public class PpnController : ControllerBase
{
    private readonly IPpnService _ppnService;

    public PpnController(IPpnService ppnService)
    {
        _ppnService = ppnService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewPpn([FromBody] Ppn payload)
    {
        try
        {
            var entryPpn = await _ppnService.Create(payload);
            return Created("/insw-dev.ilcs.co.id/n/tarif", entryPpn);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetBy([FromQuery] string hsCode)
    {
        try
        {
            var ppn = await _ppnService.GetBy(ppn => 
                ppn.Product != null && ppn.Product.CodeProduct != null && 
                ppn.Product.CodeProduct.Equals(hsCode), new[]
            {
                "Product"
            });
            return Ok(ppn);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePpn([FromBody] Ppn payload)
    {
        try
        {
            var updatePpn = await _ppnService.Update(payload);
            return Ok(updatePpn);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }
}