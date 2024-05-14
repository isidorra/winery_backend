using System.Collections.ObjectModel;

public class PricingRepository : IPricingRepository {
    private readonly DataContext _context;
    public PricingRepository(DataContext context) {
        _context = context;
    }

    public bool Create(Pricing pricing)
    {
        _context.Pricing.Add(pricing);
        return Save();
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

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public void Update(Pricing pricing)
    {
        var editedPricing = _context.Pricing.FirstOrDefault(p => p.Id == pricing.Id);
            if (editedPricing == null)
                throw new ArgumentException("Price not found");

            try
            {
                _context.Update(pricing);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit price", ex);
            }
    }

    public double? FindById(int? pricingId)
    {
        return _context.Pricing.First(x => x.Id == pricingId).Price;
    }
}