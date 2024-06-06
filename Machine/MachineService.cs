using winery_backend.Machines.Interface;

namespace winery_backend.Machines
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

        public ICollection<Machine> GetByName(string name)
        {
            return _machineRepository.GetByName(name);
        }
    }
}
