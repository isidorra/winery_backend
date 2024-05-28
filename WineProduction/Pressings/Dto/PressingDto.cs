using winery_backend.Grapes;

namespace winery_backend.WineProduction.Pressings.Dto
{
    public class PressingDto
    {
        public string grapeName { get; set; }
        public double amount { get; set; } //in litres
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string PressingType { get; set; }
        public PressingDto(string grapeName, double amount, DateTime startDate, DateTime endDate, string pressingType)
        {
            this.grapeName = grapeName;
            this.amount = amount;
            this.startDate = startDate;
            this.endDate = endDate;
            PressingType = pressingType;
        }
    }
}
