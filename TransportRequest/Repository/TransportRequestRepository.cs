using winery_backend.LogisticianViewCustomerOrder.Models;
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

        public void Update(int customerOrderId, int vanDriverId, DateTime pickUpPackagesDeadlineDate)
        {
            TransportRequest.Models.TransportRequest transportRequest = FindByCustomerOrderId(customerOrderId);
            transportRequest.VanDriverId = vanDriverId;
            transportRequest.PickUpDeadlineDate = pickUpPackagesDeadlineDate;

            _context.TransportRequests.Update(transportRequest);
            _context.SaveChanges();
        }

        public TransportRequest.Models.TransportRequest FindByCustomerOrderId(int customerOrderId)
        {
            return _context.TransportRequests.First(x => x.CustomerOrderId == customerOrderId);
        }

        public void Delete(int customerOrderId)
        {
            _context.TransportRequests.Remove(FindByCustomerOrderId(customerOrderId));
            _context.SaveChanges();
        }

        public List<TransportRequest.Models.TransportRequest> FindByVanDriverId(int vanDriverId)
        {
            return _context.TransportRequests.Where(x => x.VanDriverId == vanDriverId).ToList();
        }

        public TransportRequest.Models.TransportRequest FindById(int transportRequestId)
        {
            return _context.TransportRequests.First(x => x.TransportRequestId == transportRequestId);
        }
    }
}
