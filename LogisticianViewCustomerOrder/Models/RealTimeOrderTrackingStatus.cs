using System.ComponentModel.DataAnnotations;

namespace winery_backend.LogisticianViewCustomerOrder.Models
{
    public class RealTimeOrderTrackingStatus
    {
        public int RealTimeOrderTrackingStatusId { get; set; }
        public string OrderTrackingStatus { get; set; }

        public RealTimeOrderTrackingStatus()
        {

        }

        public RealTimeOrderTrackingStatus(int realTimeOrderTrackingStatusId, string orderTrackingStatus)
        {
            RealTimeOrderTrackingStatusId = realTimeOrderTrackingStatusId;
            OrderTrackingStatus = orderTrackingStatus;
        }
    }
}
