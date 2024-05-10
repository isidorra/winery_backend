namespace winery_backend.PackingRequest.Models
{
    public class PackingRequest
    {
        public int PackingRequestId { get; set; }
        public DateTime PackingRequestDeadlineDate { get; set; }
        public DateTime PackingRequestCreationDate { get; set; }
        public List<int> PackingRequestProductIds { get; set; }
        public List<int> PackingRequestQuantities { get; set; }
        public int CustomerOrderId { get; set; }
        public int SectorId { get; set; }

        public PackingRequest()
        {

        }

        public PackingRequest(int packingRequestId, DateTime packingRequestDeadlineDate, DateTime packingRequestCreationDate, List<int> packingRequestProductIds, List<int> packingRequestQuantities, int customerOrderId, int sectorId)
        {
            PackingRequestId = packingRequestId;
            PackingRequestDeadlineDate = packingRequestDeadlineDate;
            PackingRequestCreationDate = packingRequestCreationDate;
            PackingRequestProductIds = packingRequestProductIds;
            PackingRequestQuantities = packingRequestQuantities;
            CustomerOrderId = customerOrderId;
            SectorId = sectorId;
        }
    }
}
