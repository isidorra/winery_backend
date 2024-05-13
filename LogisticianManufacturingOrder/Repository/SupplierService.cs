using winery_backend.LogisticianManufacturingOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Interface;

namespace winery_backend.LogisticianManufacturingOrder.Repository
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
    }
}
