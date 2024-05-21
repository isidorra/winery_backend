using Microsoft.AspNetCore.Mvc;
[Route("/api/cart-product")]
[ApiController]
public class CartProductController : Controller {
    private readonly ICartProductService _cartProductService;
    private readonly ICartService _cartService;
    public CartProductController(ICartProductService cartProductService, ICartService cartService) {
        _cartProductService = cartProductService;
        _cartService = cartService;
    }

    [HttpGet("cart-product-id")]
    public IActionResult GetAById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_cartProductService.Exists(id))
            return BadRequest("Cart product does not exist.");
        
        var cartProduct = _cartProductService.GetById(id);
        return Ok(cartProduct);
    }

    [HttpGet("cart-id")]
    public IActionResult GetAllByCartId(int cartId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_cartService.Exists(cartId))
            return BadRequest("Cart does not exist.");
        
        var cartProducts = _cartProductService.GetAllByCartId(cartId);
        return Ok(cartProducts);
    }

    [HttpPost]
    public IActionResult AddToCart(CartProductDto cartProductDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        CartProduct cartProduct = new CartProduct(cartProductDto);
        if(!_cartProductService.Create(cartProduct))
            return BadRequest(ModelState);

        return Ok("Product successfully added to cart");
    }
}