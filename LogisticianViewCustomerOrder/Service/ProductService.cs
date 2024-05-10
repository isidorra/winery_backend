
using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.LogisticianViewCustomerOrder.Repository;

namespace winery_backend.LogisticianViewCustomerOrder.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> FindProductsByCustomerOrderId(List<int> productIds)
        {
            return _productRepository.FindProductsByCustomerOrderId(productIds);
        }
    }
}
