public interface IPurchaseService {
    ICollection<Purchase> GetAll();
    ICollection<Purchase> GetAllByCustomerId(int customerId);
    Purchase GetById(int id);
    bool Exists(int id);
    bool Create(Purchase purchase);
    bool Save();
    void GeneratePdfInvoice(int purchaseId);
    void Cancel(int purchaseId);
}