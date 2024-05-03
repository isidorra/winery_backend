using Microsoft.AspNetCore.Mvc;
[Route("api/product/category")]
[ApiController]
public class ProductCategoryController : Controller {
    private readonly IProductCategoryService _productCategoryService;
    public ProductCategoryController(IProductCategoryService productCategoryService) {
        _productCategoryService = productCategoryService;
    }

    [HttpGet("category")]
    public IActionResult GetById(int id) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(!_productCategoryService.Exists(id))
            return BadRequest("Product category does not exist.");

        var category = _productCategoryService.GetById(id);
        return Ok(category);
    }
}