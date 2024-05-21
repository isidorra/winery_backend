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

    [HttpGet("approved")]
    public IActionResult GetApproved() {
        var products = _productService.GetApproved();

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

    [HttpGet("approved-details")]
    public IActionResult GetApprovedById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_productService.Exists(id))
            return BadRequest("Product does not exist.");
        
        var product = _productService.GetApprovedById(id);
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

    [HttpGet("approved-category")]
    public IActionResult GetApprovedByCategoryId(int categoryId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_productCategoryService.Exists(categoryId))
            return BadRequest("Category does not exist.");

        var products = _productService.GetApprovedByCategoryId(categoryId);
        return Ok(products);
    }

    [HttpGet("search")]
    public IActionResult Search(string keyword) {
        if (string.IsNullOrEmpty(keyword))
            return BadRequest("Search keyword is required.");
        
        var products = _productService.Search(keyword);
        return Ok(products);
    }

    [HttpGet("approved-search")]
    public IActionResult SearchApproved(string keyword) {
        if (string.IsNullOrEmpty(keyword))
            return BadRequest("Search keyword is required.");
        
        var products = _productService.SearchApproved(keyword);
        return Ok(products);
    }

    [HttpPost("update")]
    public IActionResult Update(Product newProduct) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = _productService.GetById(newProduct.Id);
        if (product == null)
            return Unauthorized();

        try
        {
            _productService.Update(newProduct);
            return Ok("Successful edit");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error : {ex.Message}");
        }
    }

    [HttpPost("approve")]
    public IActionResult Approve(int productId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        if(_productService.Approve(productId))
            return Ok("Product approved");

        return BadRequest(ModelState);
    }

    [HttpPost("disapprove")]
    public IActionResult Disapprove(int productId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        
        if(_productService.Disapprove(productId))
            return Ok("Product disapproved");

        return BadRequest(ModelState);
    }
}