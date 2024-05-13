
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository) {
        _productRepository = productRepository;
    }

    public bool Approve(int productId)
    {
        Product product = _productRepository.GetById(productId);
        if(product != null && product.PricingId != 0) {
            product.IsApproved = true;
            _productRepository.Update(product);
            return true;
        } 

        return false;
    }

    public bool Disapprove(int productId)
    {
        Product product = _productRepository.GetById(productId);
        if(product != null && product.PricingId != 0) {
            product.IsApproved = false;
            _productRepository.Update(product);
            return true;
        } 

        return false;
    }

    public bool Exists(int id)
    {
        return _productRepository.Exists(id);
    }

    public ICollection<Product> GetAll()
    {
        return _productRepository.GetAll();
    }

    public ICollection<Product> GetApproved()
    {
        return _productRepository.GetAll()
                                .Where(product => product.IsApproved == true)
                                .ToList(); 
    }

    public ICollection<Product> GetApprovedByCategoryId(int categoryId)
    {
        return _productRepository.GetByCategoryId(categoryId)
                                .Where(product => product.IsApproved == true)
                                .ToList(); 
    }

    public Product GetApprovedById(int id)
    {
        Product product = _productRepository.GetById(id);
        if(product.IsApproved == true)
            return product;

        return null;

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

    public ICollection<Product> SearchApproved(string keyword)
    {
        return _productRepository.Search(keyword)
                                .Where(product => product.IsApproved == true)
                                .ToList(); ;
    }

    public void Update(Product newProduct)
    {
        
            try
            {
                Product product = _productRepository.GetById(newProduct.Id);
                if (!string.IsNullOrEmpty(newProduct.Name))
                {
                    product.Name = newProduct.Name;
                }
                if (!string.IsNullOrEmpty(newProduct.Description))
                {
                    product.Description = newProduct.Description;
                }
                if (newProduct.PricingId != 0)
                {
                    product.PricingId = newProduct.PricingId;
                }

                _productRepository.Update(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit employee", ex);
            }

        
    }
    public List<Product> FindProductsByCustomerOrderId(List<int> productIds)
    {
        return _productRepository.FindProductsByCustomerOrderId(productIds);
    }

    public int FindProductSectorIdByProductId(int id)
    {
        return _productRepository.FindProductSectorIdByProductId(id);
    }

    public List<Product> FindProductsBySectorId(int sectorId)
    {
        return _productRepository.FindProductsBySectorId(sectorId);
    }
}