using winery_backend.ViewWarehouse.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Models
{
    public class CustomerOrder
    {
        public int CustomerOrderId { get; set; }
        public decimal? CustomerOrderPrice { get; set; }
        public DateTime? CustomerOrderCreationTime { get; set; }
        public DateTime? CustomerOrderDeliveryDeadline { get; set; }
        
        public int? OrderTrackingStatusId { get; set; }
        // public List<Product>? Products { get; set; }

        //public RealTimeOrderTrackingStatus? RealTimeOrderTrackingStatus { get; set; }
    }
}
