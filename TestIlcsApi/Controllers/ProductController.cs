using Microsoft.AspNetCore.Mvc;
using TestIlcsApi.Entities;
using TestIlcsApi.Services;

namespace TestIlcsApi.Controllers;

[ApiController]
[Route("insw-dev.ilcs.co.id/n/barang")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewProduct([FromBody] Product payload)
    {
        try
        {
            var product = await _productService.Create(payload);
            return Created("/insw-dev.ilcs.co.id/n/barang", product);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpGet]
    public async Task<IActionResult> FindByCode([FromQuery] string hsCode)
    {
        try
        {
            var product = await _productService.GetBy(product => 
                product.CodeProduct != null && product.CodeProduct.Equals(hsCode));
            return Ok(product);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] Product payload)
    {
        try
        {
            var updateProduct = await _productService.Update(payload);
            return Ok(updateProduct);
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteById(string id)
    {
        try
        {
            await _productService.Delete(id);
            return Ok();
        }
        catch (Exception)
        {
            return new StatusCodeResult(500);
        }
    }
}