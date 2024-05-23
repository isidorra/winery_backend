public interface IPurchaseReviewService {
    ICollection<PurchaseReview> GetAll();
    PurchaseReview GetById(int id);
    ICollection<PurchaseReview> GetAllByPurchaseId(int purchaseId);
    bool Exists(int id);
    bool Create(PurchaseReview purchaseReview);
    bool Save();
}