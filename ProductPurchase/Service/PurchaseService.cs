
public class PurchaseService : IPurchaseService {
    private readonly IPurchaseRepository _purchaseRepository;
    public PurchaseService(IPurchaseRepository purchaseRepository) {
        _purchaseRepository = purchaseRepository;
    }

    public bool Create(Purchase purchase)
    {
        return _purchaseRepository.Create(purchase);
    }

    public bool Exists(int id)
    {
        return _purchaseRepository.Exists(id);
    }

    public void GeneratePdfInvoice(int purchaseId)
    {
        throw new NotImplementedException();
    }

    public ICollection<Purchase> GetAll()
    {
        return _purchaseRepository.GetAll();
    }

    public ICollection<Purchase> GetAllByCustomerId(int customerId)
    {
        return _purchaseRepository.GetAllByCustomerId(customerId);
    }

    public Purchase GetById(int id)
    {
        return _purchaseRepository.GetById(id);
    }

    public bool Save()
    {
        return _purchaseRepository.Save();
    }
}