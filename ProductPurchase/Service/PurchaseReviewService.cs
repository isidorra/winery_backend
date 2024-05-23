
public class PurchaseReviewService : IPurchaseReviewService
{
    private readonly IPurchaseReviewRepository _purchaseReviewRepository;
    public PurchaseReviewService(IPurchaseReviewRepository purchaseReviewRepository) {
        _purchaseReviewRepository = purchaseReviewRepository;
    }
    public bool Create(PurchaseReview purchaseReview)
    {
        return _purchaseReviewRepository.Create(purchaseReview);
    }

    public bool Exists(int id)
    {
        return _purchaseReviewRepository.Exists(id);
    }

    public ICollection<PurchaseReview> GetAll()
    {
        return _purchaseReviewRepository.GetAll();
    }

    public ICollection<PurchaseReview> GetAllByPurchaseId(int purchaseId)
    {
        return _purchaseReviewRepository.GetAllByPurchaseId(purchaseId);
    }

    public PurchaseReview GetById(int id)
    {
        return _purchaseReviewRepository.GetById(id);
    }

    public bool Save()
    {
        return _purchaseReviewRepository.Save();
    }
}