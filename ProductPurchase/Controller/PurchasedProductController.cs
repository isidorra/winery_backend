using Microsoft.AspNetCore.Mvc;
[Route("/api/purchased-product")]
[ApiController]
public class PurchasedProductController : Controller {
    private readonly IPurchasedProductService _purchasedProductService;
    private readonly IPurchaseService _purchaseService;
    public PurchasedProductController(IPurchasedProductService purchasedProductService, IPurchaseService purchaseService){
        _purchasedProductService = purchasedProductService;
        _purchaseService = purchaseService;
    }

    [HttpGet("purchase-id")]
    public IActionResult GetAllByPurchaseId(int purchaseId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_purchaseService.Exists(purchaseId))
            return BadRequest("Purchase does not exist.");
        
        var purchasedProducts = _purchasedProductService.GetAllByPurchaseId(purchaseId);
        return Ok(purchasedProducts);
    }

    [HttpGet("id")]
    public IActionResult GetById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_purchasedProductService.Exists(id))
            return BadRequest("Purchased product does not exist.");
        
        var purchasedProduct = _purchasedProductService.GetById(id);
        return Ok(purchasedProduct);
    }
}