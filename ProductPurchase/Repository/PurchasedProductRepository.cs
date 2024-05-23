
public class PurchasedProductRepository : IPurchasedProductRepository {
    private readonly DataContext _context;
    public PurchasedProductRepository(DataContext dataContext) {
        _context = dataContext;
    }

    public bool Create(PurchasedProduct purchasedProduct)
    {
        _context.PurchasedProducts.Add(purchasedProduct);
        return Save();
    }

    public bool Exists(int id)
    {
        return _context.PurchasedProducts.Any(p => p.Id == id);
    }

    public ICollection<PurchasedProduct> GetAllByPurchaseId(int purchaseId)
    {
        return _context.PurchasedProducts
                .Where(p => p.PurchaseId == purchaseId) 
                .OrderBy(c => c.Id)
                .ToList();  
    }

    public PurchasedProduct GetById(int id)
    {
        return _context.PurchasedProducts.Where(p => p.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}