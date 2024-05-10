using winery_backend.PackingRequest.Interface;

namespace winery_backend.PackingRequest.Repository
{
    public class PackingRequestRepository : IPackingRequestRepository
    {
        private readonly DataContext _context;
        public PackingRequestRepository(DataContext context)
        {
            _context = context;
        }
    }
}
