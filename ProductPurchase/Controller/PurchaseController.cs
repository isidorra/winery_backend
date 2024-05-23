using Microsoft.AspNetCore.Mvc;

[Route("/api/purchase")]
[ApiController]
public class PurchaseController : Controller {
    private readonly IPurchaseService _purchaseService;
    private readonly ICustomerService _customerService;
    private readonly IPurchasedProductService _purchasedProductService;
    private readonly ICartService _cartService;
    private readonly ICartProductService _cartProductService;
    public PurchaseController(IPurchaseService purchaseService, ICustomerService customerService, IPurchasedProductService purchasedProductService, ICartService cartService, ICartProductService cartProductService) {
        _purchaseService = purchaseService;
        _customerService = customerService;
        _purchasedProductService = purchasedProductService;
        _cartService = cartService;
        _cartProductService = cartProductService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var purchases = _purchaseService.GetAll();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(purchases);
    }

    [HttpGet("id")]
    public IActionResult GetById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_purchaseService.Exists(id))
            return BadRequest("Purchase does not exist.");
        
        var purchase = _purchaseService.GetById(id);
        return Ok(purchase);
    }

    [HttpGet("customer-id")]
    public IActionResult GetAllByCustomerId(int customerId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_customerService.Exists(customerId))
            return BadRequest("Customer does not exist.");
        
        var purchases = _purchaseService.GetAllByCustomerId(customerId);
        return Ok(purchases);
    }

    [HttpPost]
    public IActionResult Create(CreatePurchaseDto createPurchaseDto) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        Purchase purchase = new Purchase(createPurchaseDto);
        if(!_purchaseService.Create(purchase))
            return BadRequest(ModelState);

        foreach(CartProduct cartProduct in createPurchaseDto.CartProducts) {
            CreatePurchasedProductDto createPurchasedProductDto = new CreatePurchasedProductDto(purchase.Id, cartProduct.ProductId, cartProduct.Quantity);
            PurchasedProduct purchasedProduct = new PurchasedProduct(createPurchasedProductDto);
            if(!_purchasedProductService.Create(purchasedProduct))
                return BadRequest(ModelState);
        }

        Cart cart = _cartService.GetByCustomerId(purchase.CustomerId);
        List<CartProduct> cartProducts = _cartProductService.GetAllByCartId(cart.Id).ToList();
        foreach(CartProduct cp in cartProducts) {
            _cartProductService.Delete(cp.Id);
        }
        
        return Ok("Successfully created purchase.");
    }

    [HttpGet("invoice-pdf")]
    public IActionResult GeneratePdfInvoice(int purchaseId) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        _purchaseService.GeneratePdfInvoice(purchaseId);
        return Ok("Successs");
    }

    [HttpPost("cancel")]
    public IActionResult CancelPurchase(int purchaseId) {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_purchaseService.Exists(purchaseId))
            return BadRequest("Purchase does not exist.");

        _purchaseService.Cancel(purchaseId);
        return Ok("Purchase canceled.");
    }
}