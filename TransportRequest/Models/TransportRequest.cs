namespace winery_backend.TransportRequest.Models
{
    public class TransportRequest
    {
        public int TransportRequestId { get; set; }
        public DateTime PickUpDeadlineDate { get; set; }
        public DateTime TransportRequestCreationDate { get; set; }
        public DateTime TransportRequestDeliveryDeadlineDate { get; set; }
        public List<int> SectorIdsForPickUp { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerDeliveryAddress { get; set; }
        public int CustomerOrderId {  get; set; }
        public int VanDriverId { get; set; }

        public TransportRequest()
        {

        }

        public TransportRequest(int transportRequestId, DateTime pickUpDeadlineDate, DateTime transportRequestCreationDate, DateTime transportRequestDeliveryDeadlineDate, List<int> sectorIdsForPickUp, string customerUsername, string customerDeliveryAddress, int customerOrderId, int vanDriverId)
        {
            TransportRequestId = transportRequestId;
            PickUpDeadlineDate = pickUpDeadlineDate;
            TransportRequestCreationDate = transportRequestCreationDate;
            TransportRequestDeliveryDeadlineDate = transportRequestDeliveryDeadlineDate;
            SectorIdsForPickUp = sectorIdsForPickUp;
            CustomerUsername = customerUsername;
            CustomerDeliveryAddress = customerDeliveryAddress;
            CustomerOrderId = customerOrderId;
            VanDriverId = vanDriverId;
        }
    }
}
