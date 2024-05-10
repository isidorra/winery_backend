using winery_backend.ViewWarehouse.Interface;

namespace winery_backend.ViewWarehouse.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DataContext _context;
        public WarehouseRepository(DataContext context)
        {
            _context = context;
        }
    }
}
