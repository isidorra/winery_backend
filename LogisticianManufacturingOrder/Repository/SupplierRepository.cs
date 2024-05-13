using winery_backend.LogisticianManufacturingOrder.Interface;

namespace winery_backend.LogisticianManufacturingOrder.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext _context;
        public SupplierRepository(DataContext context)
        {
            _context = context;
        }
    }
}
