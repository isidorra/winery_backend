
public class DiscountRepository : IDiscountRepository {
    private readonly DataContext _context;
    public DiscountRepository(DataContext context) {
        _context = context;
    }

    public bool Create(Discount discount)
    {
        _context.Discounts.Add(discount);
        return Save();
    }

    public bool Delete(int id)
    {
        var discountToDelete = _context.Discounts.FirstOrDefault(d => d.Id == id);

        if (discountToDelete != null)
        {
            _context.Discounts.Remove(discountToDelete);
            _context.SaveChanges();
            return true; 
        }

        return false;
    }

    public bool Exists(int id)
    {
        return _context.Discounts.Any(d => d.Id == id);
    }

    public ICollection<Discount> GetAll()
    {
        return _context.Discounts.OrderBy(d => d.Id).ToList();
    }

    public Discount GetById(int id)
    {
        return _context.Discounts.Where(d => d.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}