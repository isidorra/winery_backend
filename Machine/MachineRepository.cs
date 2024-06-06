using Microsoft.EntityFrameworkCore;
using Supplies;
using System.Collections.ObjectModel;
using winery_backend.Machines.Interface;

namespace winery_backend.Machines
{
    public class MachineRepository : IMachineRepository
    {
        private readonly DataContext _context;

        public MachineRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Machine> GetAll()
        {
            return _context.Machines.OrderBy(s => s.Id).ToList();
        }

        public Machine GetById(int id)
        {
            return _context.Machines.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public ICollection<Machine> GetByName(string name)
        {
            ICollection<Machine> allMachines = GetAll();
            ICollection<Machine> fillteredMachines = new Collection<Machine>();

            foreach (var machine in allMachines)
            {
                if (machine.Name.Contains(name))
                {
                    fillteredMachines.Add(machine);
                }
            }

            return fillteredMachines;
        }
    }
}
