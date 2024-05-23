using Microsoft.AspNetCore.Mvc;
[Route("/api/purchase-review")]
[ApiController]
public class PurchaseReviewController : Controller {
    private readonly IPurchaseReviewService _purchaseReviewService;
    private readonly IPurchaseService _purchaseService;
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseReviewController(IPurchaseReviewService purchaseReviewService, IPurchaseService purchaseService, IPurchaseRepository purchaseRepository) {
        _purchaseReviewService = purchaseReviewService;
        _purchaseService = purchaseService;
        _purchaseRepository = purchaseRepository;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var purchaseReviews = _purchaseReviewService.GetAll();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(purchaseReviews);
    }

    [HttpGet("purchase-id")]
    public IActionResult GetAllByPurchaseId(int purchaseId) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_purchaseService.Exists(purchaseId))
            return BadRequest("Purchase does not exist.");
        
        var purchaseReviews = _purchaseReviewService.GetAllByPurchaseId(purchaseId);
        return Ok(purchaseReviews);
    }

    [HttpGet("id")]
    public IActionResult GetById(int id) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if(!_purchaseReviewService.Exists(id))
            return BadRequest("Purchase review does not exist.");
        
        var review = _purchaseReviewService.GetById(id);
        return Ok(review);
    }

    [HttpPost]
    public IActionResult Create(PurchaseReviewDto purchaseReviewDto) {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        PurchaseReview purchaseReview = new PurchaseReview(purchaseReviewDto);
        if(!_purchaseReviewService.Create(purchaseReview))
            return BadRequest(ModelState);

        Purchase purchase = _purchaseService.GetById(purchaseReviewDto.PurchaseId);
        purchase.PurchaseStatus = PurchaseStatus.REVIEWED;
        _purchaseRepository.Update(purchase);

        return Ok("Review successfully created");
    }

}