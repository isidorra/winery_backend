using winery_backend.Machines.Interface;

namespace winery_backend.Machines
{
    public class MachineOrderRepository : IMachineOrderRepository
    {
        private readonly DataContext _context;

        public MachineOrderRepository(DataContext context)
        {
            _context = context;
        }
    }
}
