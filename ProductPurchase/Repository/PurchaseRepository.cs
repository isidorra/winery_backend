
public class PurchaseRepository : IPurchaseRepository {
    private readonly DataContext _context;
    public PurchaseRepository(DataContext dataContext) {
        _context = dataContext;
    }

    public bool Create(Purchase purchase)
    {
        _context.Purchases.Add(purchase);
        return Save();
    }

    public bool Exists(int id)
    {
        return _context.Purchases.Any(p => p.Id == id);
    }

    public ICollection<Purchase> GetAll()
    {
        return _context.Purchases.OrderBy(p => p.Id).ToList();
    }

    public ICollection<Purchase> GetAllByCustomerId(int customerId)
    {
        return _context.Purchases
                .Where(p => p.CustomerId == customerId) 
                .OrderBy(c => c.Id)
                .ToList();  
    }

    public Purchase GetById(int id)
    {
        return _context.Purchases.Where(p => p.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public void Update(Purchase purchase)
    {
        var editedPurchase = _context.Purchases.FirstOrDefault(p => p.Id == purchase.Id);
        if (editedPurchase == null)
            throw new ArgumentException("Purchase not found");

        try
        {
            _context.Update(purchase);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Error while trying to edit purchase", ex);
        }
    }
}