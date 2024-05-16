using winery_backend.Machine.Interface;

namespace winery_backend.Machine
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;

        public MachineService(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        public ICollection<Machine> GetAll()
        {
            return _machineRepository.GetAll();
        }

        public Machine GetById(int id)
        {
            return _machineRepository.GetById(id);
        }
    }
}
