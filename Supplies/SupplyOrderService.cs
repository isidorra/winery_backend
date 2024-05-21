

using winery_backend.Supplies.Interface;

public class SupplyOrderService : ISupplyOrderService
    {
        private readonly ISupplyOrderRepository _supplyOrderRepository;
        public SupplyOrderService(ISupplyOrderRepository supplyOrderRepository)
        {
            _supplyOrderRepository = supplyOrderRepository;
        }
    }

