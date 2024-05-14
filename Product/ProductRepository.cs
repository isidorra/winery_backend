
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

    public void Update(Product product)
    {
        var editedProduct = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (editedProduct == null)
                throw new ArgumentException("Product not found");

            try
            {
                _context.Update(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit product", ex);
            }
    }
    public List<Product> FindProductsByCustomerOrderId(List<int> productIds)
        {
            List<Product> products = new List<Product>();

            foreach (var productId in productIds)
            {
                Product product = _context.Products.First(x => x.Id == productId);
                products.Add(product);
            }
            return products;
        }

    public int FindProductSectorIdByProductId(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id).SectorId;
    }

    public List<Product> FindProductsBySectorId(int sectorId)
    {
        return _context.Products.Where(x => x.SectorId == sectorId).ToList();
    }

    public string FindProductNameById(int productId)
    {
        return _context.Products.First(x => x.Id == productId).Name;
    }

    public void UpdateProductQuantity(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public Product FindProductByProductName(string productName)
    {
        return _context.Products.First(x => x.Name.Equals(productName));
    }
}