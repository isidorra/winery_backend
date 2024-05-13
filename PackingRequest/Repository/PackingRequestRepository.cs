using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Interface;
using winery_backend.PackingRequest.Models;
using winery_backend.ViewWarehouse.Models;

namespace winery_backend.PackingRequest.Repository
{
    public class PackingRequestRepository : IPackingRequestRepository
    {
        private readonly DataContext _context;
        public PackingRequestRepository(DataContext context)
        {
            _context = context;
        }

        public bool IsExistPackingRequestBySectorIdAndCustomerOrderId(int sectorId, int customerOrderId)
        {
            return _context.PackingRequests.Any(x => x.SectorId == sectorId && x.CustomerOrderId == customerOrderId);
        }

        public int FindLastId()
        {
            if (_context.PackingRequests.Count() == 0)
            {
                return 1;
            }
            return _context.PackingRequests.Max(x => x.PackingRequestId) + 1;
        }

        public bool SavePackingRequest(PackingRequest.Models.PackingRequest packingRequest)
        {
            if(_context.PackingRequests.Any(x => x.CustomerOrderId == packingRequest.CustomerOrderId && x.SectorId == packingRequest.SectorId))
            {
                return false;
            }
            _context.PackingRequests.Add(packingRequest);
            _context.SaveChanges();

            return true;
        }

        public List<PackingRequest.Models.PackingRequest> FindPackingRequestByCustomerOrderId(int customerOrderId)
        {
            return _context.PackingRequests.Where(x => x.CustomerOrderId == customerOrderId).ToList();
        }
    }
}
