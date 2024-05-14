namespace winery_backend.VanDriverTransportRequest.Dto
{
    public class PickedUpDto
    {
        public string CustomerUsername { get; set; }
        public string DeliveryAddress { get; set; }

        public PickedUpDto()
        {

        }

        public PickedUpDto(string customerUsername, string deliveryAddress)
        {
            CustomerUsername = customerUsername;
            DeliveryAddress = deliveryAddress;
        }
    }
}
