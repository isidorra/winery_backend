namespace winery_backend.WarehousemanPackingRequest.Dto
{
    public class WarehousemanPackingRequestsViewDto
    {
        public int PackingRequestId { get; set; }
        public DateTime PackingRequestDeadlineDate { get; set; }

        public WarehousemanPackingRequestsViewDto()
        {

        }

        public WarehousemanPackingRequestsViewDto(int packingRequestId, DateTime packingRequestDeadlineDate)
        {
            PackingRequestId = packingRequestId;
            PackingRequestDeadlineDate = packingRequestDeadlineDate;
        }
    }
}
