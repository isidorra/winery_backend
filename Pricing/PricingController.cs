using Microsoft.AspNetCore.Mvc;
[Route("api/product/pricing")]
[ApiController]
public class PricingController : Controller {
    private readonly IPricingService _pricingService;
    public PricingController(IPricingService pricingService) {
        _pricingService = pricingService;
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
}