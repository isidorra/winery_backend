namespace winery_backend.PackingRequest.Models
{
    public class PackingRequest
    {
        public int PackingRequestId { get; set; }
        public DateTime PackingRequestDeadlineDate { get; set; }
        public DateTime PackingRequestCreationDate { get; set; }
        public int WarehousemanId { get; set; }

    }
}
