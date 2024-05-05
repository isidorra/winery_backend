namespace winery_backend.Activity.Dto
{
    public class WateringDto
    {
        public string parcelId { get; set; }
        public DateTime startDate { get; set; }
        public string amount { get; set; }

        public WateringDto(string parcelId, DateTime startDate, string amount)
        {
            this.parcelId = parcelId;
            this.startDate = startDate;
            this.amount = amount;
        }
    }
}
