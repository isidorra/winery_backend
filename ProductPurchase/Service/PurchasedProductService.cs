
public class PurchasedProductService : IPurchasedProductService {
    private readonly IPurchasedProductRepository _purchasedProductRepository;
    public PurchasedProductService(IPurchasedProductRepository purchasedProductRepository) {
        _purchasedProductRepository = purchasedProductRepository;
    }

    public bool Create(PurchasedProduct purchasedProduct)
    {
        return _purchasedProductRepository.Create(purchasedProduct);
    }

    public bool Exists(int id)
    {
        return _purchasedProductRepository.Exists(id);
    }

    public ICollection<PurchasedProduct> GetAllByPurchaseId(int purchaseId)
    {
        return _purchasedProductRepository.GetAllByPurchaseId(purchaseId);
    }

    public PurchasedProduct GetById(int id)
    {
        return _purchasedProductRepository.GetById(id);
    }

    public bool Save()
    {
        return _purchasedProductRepository.Save();
    }
}