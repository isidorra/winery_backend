using winery_backend.PackingRequest.Models;
using winery_backend.TransportRequest.Interface;

namespace winery_backend.TransportRequest.Repository
{
    public class TransportRequestRepository : ITransportRequestRepository
    {
        private readonly DataContext _context;
        public TransportRequestRepository(DataContext context)
        {
            _context = context;
        }

        public bool SaveTransportRequest(TransportRequest.Models.TransportRequest transportRequest)
        {
            if (_context.TransportRequests.Any(x => x.CustomerOrderId == transportRequest.CustomerOrderId))
            {
                return false;
            }
            _context.TransportRequests.Add(transportRequest);
            _context.SaveChanges();

            return true;
        }

        public int FindLastId()
        {
            if (_context.TransportRequests.Count() == 0)
            {
                return 1;
            }
            return _context.TransportRequests.Max(x => x.TransportRequestId) + 1;
        }
    }
}
