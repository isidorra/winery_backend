namespace winery_backend.WineProduction.Fermentations.Dto
{
    public class FermentationDto
    {
        public string grapeId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public double amount { get; set; }
        public double sugar { get; set; }
        public double yeast { get; set; }
        public double temperature { get; set; }
        public double ph { get; set; }

        public FermentationDto(string grapeId, DateTime startDate, DateTime endDate, double amount, double sugar, double yeast, double temperature, double ph)
        {
            this.grapeId = grapeId;
            this.startDate = startDate;
            this.endDate = endDate;
            this.amount = amount;
            this.sugar = sugar;
            this.yeast = yeast;
            this.temperature = temperature;
            this.ph = ph;
        }
    }
}
