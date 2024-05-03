using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductController : Controller {

    private readonly IProductService _productService;

    public ProductController(IProductService productService) {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var products = _productService.GetAll();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(products);
    }

    [HttpGet("details")]
    public IActionResult GetById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_productService.Exists(id))
            return BadRequest("Product does not exist.");
        
        var product = _productService.GetById(id);
        return Ok(product);
    }
}