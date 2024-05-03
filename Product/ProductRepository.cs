
using Microsoft.EntityFrameworkCore;

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

    public ICollection<Product> GetByCategoryId(int categoryId)
    {
        return _context.Products.Where(p => p.ProductCategoryId == categoryId).ToList();
    }

    public Product GetById(int id)
    {
        return _context.Products.Where(p => p.Id == id).FirstOrDefault();
    }

    public ICollection<Product> Search(string keyword) {
        
        var products = _context.Products.Where(p=> 
            EF.Functions.Like(p.Name, $"%{keyword}%") || 
            EF.Functions.Like(p.Description, $"%{keyword}%") || 
            EF.Functions.Like(p.ProductCategory.Name, $"%{keyword}%"));

        return products.ToList();
    }
}