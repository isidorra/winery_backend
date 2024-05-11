using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Interface
{
    public interface IProductService
    {
        List<Product> FindProductsByCustomerOrderId(List<int> productIds);
        int FindProductSectorIdByProductId(int id);
        List<Product> FindProductsBySectorId(int sectorId);
    }
}
