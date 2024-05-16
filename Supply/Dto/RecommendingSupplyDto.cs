namespace winery_backend.Invetory.Dto
{
    public class RecommendingSupplyDto
    {
        public double amount { get; set; }
        public Supply.Supply fertilizer { get; set; }
        public RecommendingSupplyDto(double amount, Supply.Supply fertilizer)
        {
            this.amount = amount;
            this.fertilizer = fertilizer;
        }
    }
}
