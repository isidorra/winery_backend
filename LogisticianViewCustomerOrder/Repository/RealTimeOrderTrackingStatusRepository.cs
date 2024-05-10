using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Repository
{
    public class RealTimeOrderTrackingStatusRepository : IRealTimeOrderTrackingStatusRepository
    {
        private readonly DataContext _context;
        public RealTimeOrderTrackingStatusRepository(DataContext context)
        {
            _context = context;
        }

        public string FindStatusNameById(int id)
        {
            return _context.RealTimeOrderTrackingStatuses.First(x => x.RealTimeOrderTrackingStatusId == id).OrderTrackingStatus.ToString();
        }
    }
}
