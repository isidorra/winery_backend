using Microsoft.AspNetCore.Mvc;

[Route("api/discounts")]
[ApiController]
public class DiscountController : Controller {
    private readonly IDiscountService _discountService;
    private readonly IPricingService _pricingService;
    public DiscountController(IDiscountService discountService, IPricingService pricingService) {
        _discountService = discountService;
        _pricingService = pricingService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var discounts = _discountService.GetAll();
        return Ok(discounts);
    }

    [HttpGet("details")]
    public IActionResult GetById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_discountService.Exists(id))
            return BadRequest("Discount does not exist.");
        
        var discount = _discountService.GetById(id);
        return Ok(discount);
    }

    [HttpPost("create")]
    public IActionResult Create(CreateDiscountDto createDiscountDto) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        Discount discount = new Discount(createDiscountDto);
        if(!_discountService.Create(discount))
            return BadRequest(ModelState);

        Pricing pricing = _pricingService.GetById(createDiscountDto.PricingId);
        pricing.DiscountId = discount.Id;
        _pricingService.Update(pricing);

        return Ok("Successfully created new discount.");
    }

    [HttpPost("delete")]
    public IActionResult Delete(int id, int pricingId) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(!_discountService.Exists(id))
            return BadRequest("Discount does not exist.");

        Pricing pricing = _pricingService.GetById(pricingId);
        pricing.DiscountId = null;
        _pricingService.Update(pricing);

        _discountService.Delete(id);

        return Ok("Successfully deleted discount.");
        
    }
}