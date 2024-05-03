
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository) {
        _productRepository = productRepository;
    }

    public bool Exists(int id)
    {
        return _productRepository.Exists(id);
    }

    public ICollection<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    public ICollection<Product> GetByCategoryId(int categoryId)
    {
        return _productRepository.GetByCategoryId(categoryId);
    }

    public Product GetById(int id)
    {
        return _productRepository.GetById(id);
    }

    public ICollection<Product> Search(string keyword)
    {
        return _productRepository.Search(keyword);
    }
}