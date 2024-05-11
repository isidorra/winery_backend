
using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.LogisticianViewCustomerOrder.Repository;
using winery_backend.ViewWarehouse.Models;

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

        public int FindProductSectorIdByProductId(int id)
        {
            return _productRepository.FindProductSectorIdByProductId(id);
        }

        public List<Product> FindProductsBySectorId(int sectorId)
        {
            return _productRepository.FindProductsBySectorId(sectorId);
        }
    }
}
