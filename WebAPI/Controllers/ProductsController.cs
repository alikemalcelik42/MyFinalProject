using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();

        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getbyid")]
    public IActionResult GetAll(int id)
    {
        var result = _productService.GetById(id);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getallbycategoryid")]
    public IActionResult GetAllByCategoryId(int categoryId)
    {
        var result = _productService.GetAllByCategoryId(categoryId);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet("getallbyunitprice")]
    public IActionResult GetAllByUnitPrice(int min, int max)
    {
        var result = _productService.GetAllByUnitPrice(min, max);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        var result = _productService.Add(product);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("update")]
    public IActionResult Update(Product product)
    {
        var result = _productService.Update(product);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost("delete")]
    public IActionResult Delete(Product product)
    {
        var result = _productService.Delete(product);
        if (result.Success)
            return Ok(result);
        return BadRequest(result);
    }
}