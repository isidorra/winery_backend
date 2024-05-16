using winery_backend.Supply.Interface;

namespace winery_backend.Supply
{
    public class SupplyOrderRepository : ISupplyOrderRepository
    {
        private readonly DataContext _context;
        public SupplyOrderRepository(DataContext context)
        {
            _context = context;
        }
    }
}
