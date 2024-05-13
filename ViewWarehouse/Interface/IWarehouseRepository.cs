using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Interface
{
    public interface IWarehouseRepository
    {
        Warehouse FindWarehouse();
    }
}
