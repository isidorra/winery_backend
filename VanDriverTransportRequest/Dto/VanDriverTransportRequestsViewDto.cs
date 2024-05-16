namespace winery_backend.VanDriverTransportRequest.Dto
{
    public class VanDriverTransportRequestsViewDto
    {
        public int TransportRequestId { get; set; }
        public string OrderTrackingStatus { get; set; }
        public DateTime PickUpDeadlineDate { get; set; }

        public VanDriverTransportRequestsViewDto()
        {

        }

        public VanDriverTransportRequestsViewDto(int transportRequestId, string orderTrackingStatus, DateTime pickUpDeadlineDate)
        {
            TransportRequestId = transportRequestId;
            OrderTrackingStatus = orderTrackingStatus;
            PickUpDeadlineDate = pickUpDeadlineDate;
        }
    }
}
