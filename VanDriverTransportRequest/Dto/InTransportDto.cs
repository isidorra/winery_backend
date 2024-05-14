namespace winery_backend.VanDriverTransportRequest.Dto
{
    public class InTransportDto
    {
        public string CustomerUsername { get; set; }
        public string DeliveryAddress { get; set; }

        public InTransportDto()
        {

        }

        public InTransportDto(string customerUsername, string deliveryAddress)
        {
            CustomerUsername = customerUsername;
            DeliveryAddress = deliveryAddress;
        }
    }
}
