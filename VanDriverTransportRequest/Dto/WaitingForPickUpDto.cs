namespace winery_backend.VanDriverTransportRequest.Dto
{
    public class WaitingForPickUpDto
    {
        public string CustomerUsername { get; set; }
        public string DeliveryAddress { get; set; }

        public WaitingForPickUpDto()
        {

        }

        public WaitingForPickUpDto(string customerUsername, string deliveryAddress)
        {
            CustomerUsername = customerUsername;
            DeliveryAddress = deliveryAddress;
        }
    }
}
