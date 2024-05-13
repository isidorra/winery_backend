using winery_backend.LogisticianManufacturingOrder.Interface;

namespace winery_backend.LogisticianManufacturingOrder.Repository
{
    public class SupplierProductRepository : ISupplierProductRepository
    {
        private readonly DataContext _context;
        public SupplierProductRepository(DataContext context)
        {
            _context = context;
        }
    }
}
