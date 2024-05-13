using winery_backend.Machine.Interface;

namespace winery_backend.Machine
{
    public class MachineOrderService : IMachineOrderService
    {
        private readonly IMachineOrderRepository _machineOrderRepository;

        public MachineOrderService(IMachineOrderRepository machineOrderRepository)
        {
            _machineOrderRepository = machineOrderRepository;
        }
    }
}
