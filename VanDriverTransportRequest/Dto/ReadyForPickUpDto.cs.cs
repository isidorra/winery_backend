namespace winery_backend.VanDriverTransportRequest.Dto
{
    public class ReadyForPickUpDto
    {
        public string CustomerUsername { get; set; }
        public string DeliveryAddress { get; set; }
        public List<string> SectorNames { get; set; }

        public ReadyForPickUpDto()
        {

        }

        public ReadyForPickUpDto(string customerUsername, string deliveryAddress, List<string> sectorNames)
        {
            CustomerUsername = customerUsername;
            DeliveryAddress = deliveryAddress;
            SectorNames = sectorNames;
        }
    }
}
