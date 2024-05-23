
public class PurchaseReviewRepository : IPurchaseReviewRepository
{
    private readonly DataContext _context;
    public PurchaseReviewRepository(DataContext context) {
        _context = context;
    }
    public bool Create(PurchaseReview purchaseReview)
    {
        _context.PurchaseReviews.Add(purchaseReview);
        return Save();
    }

    public bool Exists(int id)
    {
        return _context.PurchaseReviews.Any(c => c.Id == id);
    }

    public ICollection<PurchaseReview> GetAll()
    {
        return _context.PurchaseReviews.OrderBy(c => c.Id).ToList();
    }

    public PurchaseReview GetById(int id)
    {
        return _context.PurchaseReviews.Where(c => c.Id == id).FirstOrDefault();
    }

    public ICollection<PurchaseReview> GetAllByPurchaseId(int purchaseId)
    {
        return _context.PurchaseReviews
                .Where(c => c.PurchaseId == purchaseId)
                .OrderBy(c => c.Id)
                .ToList();  
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}