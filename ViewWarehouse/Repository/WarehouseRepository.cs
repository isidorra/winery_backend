using winery_backend.ViewWarehouse.Interface;
using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DataContext _context;
        public WarehouseRepository(DataContext context)
        {
            _context = context;
        }

        public Warehouse FindWarehouse()
        {
            return _context.Warehouses.First();
        }
    }
}
