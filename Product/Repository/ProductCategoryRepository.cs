
public class ProductCategoryRepository : IProductCategoryRepository {
    private readonly DataContext _context; 
    public ProductCategoryRepository(DataContext context) {
        _context = context;
    }

    public bool Exists(int id)
    {
        return _context.ProductCategories.Any(pc => pc.Id == id);
    }

    public ICollection<ProductCategory> GetAll()
    {
        return _context.ProductCategories.OrderBy(pc => pc.Id).ToList();
    }

    public ProductCategory GetById(int id)
    {
        return _context.ProductCategories.Where(pc => pc.Id == id).FirstOrDefault();
    }

    public string FindById(int? productCategoryId)
    {
        return _context.ProductCategories.First(x => x.Id == productCategoryId).Name;
    }
}