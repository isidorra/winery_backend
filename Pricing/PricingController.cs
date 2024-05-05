using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
[Route("api/product/pricing")]
[ApiController]
public class PricingController : Controller {
    private readonly IPricingService _pricingService;
    private readonly IProductService _productService;
    public PricingController(IPricingService pricingService, IProductService productService) {
        _pricingService = pricingService;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var prices = _pricingService.GetAll();
        return Ok(prices);
    }

    [HttpGet("price")]
    public IActionResult GetById(int id) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(!_pricingService.Exists(id))
            return BadRequest("Price does not exist.");

        var price = _pricingService.GetById(id);
        return Ok(price);
    }

    [HttpPost("create-price")]
    public IActionResult Create(CreatePriceDto createPriceDto) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        Pricing pricing = new Pricing(createPriceDto);
        if(!_pricingService.Create(pricing))
            return BadRequest(ModelState);

        Product product = _productService.GetById(createPriceDto.ProductId);
        product.PricingId = pricing.Id;
        _productService.Update(product);

        return Ok("Successfully created new price.");
    }

    [HttpPost("update")]
    public IActionResult Update(UpdatePriceDto updatePriceDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pricing = _pricingService.GetById(updatePriceDto.Id);
        if (pricing == null)
            return Unauthorized();

        Pricing newPricing = new Pricing(updatePriceDto);

        try
        {
            _pricingService.Update(newPricing);
            return Ok("Successful edit of pricing");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error : {ex.Message}");
        }

        
    }
}