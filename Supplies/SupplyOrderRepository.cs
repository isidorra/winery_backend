using winery_backend.Supplies.Interface;


    public class SupplyOrderRepository : ISupplyOrderRepository
    {
        private readonly DataContext _context;
        public SupplyOrderRepository(DataContext context)
        {
            _context = context;
        }
    }

