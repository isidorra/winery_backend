public interface IPurchasedProductService {
    ICollection<PurchasedProduct> GetAllByPurchaseId(int purchaseId);
    PurchasedProduct GetById(int id);
    bool Exists(int id);
    bool Create(PurchasedProduct purchasedProduct);
    bool Save();
}