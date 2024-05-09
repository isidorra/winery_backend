namespace winery_backend.TransportRequest.Models
{
    public class TransportRequest
    {
        public int TransportRequestId { get; set; }
        public DateTime? PickUpDeadlineDate { get; set; }
        public DateTime? TransportRequestCreationDate { get; set; }


    }
}
