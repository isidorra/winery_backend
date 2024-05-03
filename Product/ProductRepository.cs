
public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;
    public ProductRepository(DataContext context) {
        _context = context;
    }

    public bool Exists(int id)
    {
        return _context.Products.Any(p => p.Id == id);
    }

    public ICollection<Product> GetAll()
    {
        return _context.Products.OrderBy(p => p.Id).ToList();
    }

    public Product GetById(int id)
    {
        return _context.Products.Where(p => p.Id == id).FirstOrDefault();
    }
}