using System.Diagnostics;
using winery_backend.ViewWarehouse.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Models
{
    public class CustomerOrder
    {
        public int CustomerOrderId { get; set; }
        public decimal CustomerOrderPrice { get; set; }
        public DateTime CustomerOrderCreationTime { get; set; }
        public DateTime CustomerOrderDeliveryDeadline { get; set; }
        public int OrderTrackingStatusId { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> Quantities { get; set; }
        public int CustomerId {  get; set; }

        public CustomerOrder()
        {

        }

        public CustomerOrder(int customerOrderId, decimal customerOrderPrice, DateTime customerOrderCreationTime, DateTime customerOrderDeliveryDeadline, int orderTrackingStatusId, List<int> productIds, List<int> quantities, int customerId)
        {
            CustomerOrderId = customerOrderId;
            CustomerOrderPrice = customerOrderPrice;
            CustomerOrderCreationTime = customerOrderCreationTime;
            CustomerOrderDeliveryDeadline = customerOrderDeliveryDeadline;
            OrderTrackingStatusId = orderTrackingStatusId;
            ProductIds = productIds;
            Quantities = quantities;
            CustomerId = customerId;
        }

    }
}
