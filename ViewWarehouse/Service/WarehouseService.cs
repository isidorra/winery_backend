using winery_backend.ViewWarehouse.Interface;
using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Service
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public WarehouseService(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public Warehouse FindWarehouse()
        {
            return _warehouseRepository.FindWarehouse();
        }
    }
}
