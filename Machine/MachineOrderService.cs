using winery_backend.Machines.Interface;

namespace winery_backend.Machines
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
