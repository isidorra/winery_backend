using Microsoft.AspNetCore.Mvc;
[Route("/api/cart")]
[ApiController]
public class CartController : Controller {
    private readonly ICartService _cartService;
    private readonly ICustomerService _customerService;
    public CartController(ICartService cartService, ICustomerService customerService) {
        _cartService = cartService;
        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var carts = _cartService.GetAll();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(carts);
    }

    [HttpGet("cart-id")]
    public IActionResult GetById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_cartService.Exists(id))
            return BadRequest("Cart does not exist.");
        
        var cart = _cartService.GetById(id);
        return Ok(cart);
    }

    [HttpGet("customer-id")]
    public IActionResult GetByCustomerId(int customerId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_customerService.Exists(customerId))
            return BadRequest("Customer does not exist.");
        
        var cart = _cartService.GetByCustomerId(customerId);
        return Ok(cart);
    }
}