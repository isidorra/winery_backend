namespace winery_backend.LogisticianViewCustomerOrder.Dto
{
    public class LogisticianCustomerOrdersViewDto
    {
        public int CustomerOrderId { get; set; }
        public string OrderTrackingStatus { get; set; }
        public DateTime CustomerOrderDeliveryDeadline { get; set; }

        public LogisticianCustomerOrdersViewDto()
        {

        }

        public LogisticianCustomerOrdersViewDto(int customerOrderId, string orderTrackingStatus, DateTime customerOrderDeliveryDeadline)
        {
            CustomerOrderId = customerOrderId;
            OrderTrackingStatus = orderTrackingStatus;
            CustomerOrderDeliveryDeadline = customerOrderDeliveryDeadline;
        }
    }
}
