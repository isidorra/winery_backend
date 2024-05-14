using winery_backend.Supply.Interface;

namespace winery_backend.Supply
{
    public class SupplyOrderService : ISupplyOrderService
    {
        private readonly ISupplyOrderRepository _supplyOrderRepository;
        public SupplyOrderService(ISupplyOrderRepository supplyOrderRepository)
        {
            _supplyOrderRepository = supplyOrderRepository;
        }
    }
}
