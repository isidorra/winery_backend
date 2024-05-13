using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Service
{
    public class RealTimeOrderTrackingStatusService : IRealTimeOrderTrackingStatusService
    {
        private readonly IRealTimeOrderTrackingStatusRepository _realTimeOrderTrackingStatusRepository;
        public RealTimeOrderTrackingStatusService(IRealTimeOrderTrackingStatusRepository realTimeOrderTrackingStatusRepository)
        {
            _realTimeOrderTrackingStatusRepository = realTimeOrderTrackingStatusRepository;
        }

        public string FindStatusNameById(int id)
        {
            return _realTimeOrderTrackingStatusRepository.FindStatusNameById(id);
        }

        public int FindIdByStatusName(string newStatusName)
        {
            return _realTimeOrderTrackingStatusRepository.FindIdByStatusName(newStatusName);
        }
    }
}
