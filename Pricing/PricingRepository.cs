using System.Collections.ObjectModel;

public class PricingRepository : IPricingRepository {
    private readonly DataContext _context;
    public PricingRepository(DataContext context) {
        _context = context;
    }

    public bool Exists(int id)
    {
        return _context.Pricing.Any(p => p.Id == id);
    }

    public ICollection<Pricing> GetAll()
    {
        return _context.Pricing.OrderBy(p => p.Id).ToList();
    }

    public Pricing GetById(int id)
    {
        return _context.Pricing.Where(p => p.Id == id).FirstOrDefault();
    }
}