
public class ProductCategoryService : IProductCategoryService {
    private readonly IProductCategoryRepository _productCategoryRepository;
    public ProductCategoryService(IProductCategoryRepository productCategoryRepository) {
        _productCategoryRepository = productCategoryRepository;
    }

    public bool Exists(int id)
    {
        return _productCategoryRepository.Exists(id);
    }

    public ICollection<ProductCategory> GetAll()
    {
        return _productCategoryRepository.GetAll();
    }

    public ProductCategory GetById(int id)
    {
        return _productCategoryRepository.GetById(id);
    }
}