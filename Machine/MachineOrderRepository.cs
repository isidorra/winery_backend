using winery_backend.Machine.Interface;

namespace winery_backend.Machine
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
