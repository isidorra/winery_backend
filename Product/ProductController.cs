using Microsoft.AspNetCore.Mvc;

[Route("api/products")]
[ApiController]
public class ProductController : Controller {

    private readonly IProductService _productService;
    private readonly IProductCategoryService _productCategoryService;

    public ProductController(IProductService productService, IProductCategoryService productCategoryService) {
        _productService = productService;
        _productCategoryService = productCategoryService;
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
    [HttpGet("category")]
    public IActionResult GetByCategoryId(int categoryId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_productCategoryService.Exists(categoryId))
            return BadRequest("Category does not exist.");

        var products = _productService.GetByCategoryId(categoryId);
        return Ok(products);
    }

    [HttpPost("search")]
public IActionResult Search([FromBody] string keyword) {
    if (string.IsNullOrEmpty(keyword))
        return BadRequest("Search keyword is required.");
    
    var products = _productService.Search(keyword);
    return Ok(products);
}
}