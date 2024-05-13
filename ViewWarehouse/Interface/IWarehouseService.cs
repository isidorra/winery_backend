using winery_backend.ViewWarehouse.Models;
using winery_backend.ViewWarehouse.Repository;

namespace winery_backend.ViewWarehouse.Interface
{
    public interface IWarehouseService
    {
        Warehouse FindWarehouse();
    }
}
