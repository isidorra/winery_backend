namespace winery_backend.Invetory.Dto
{
    public class RecommendingSupplyDto
    {
        public long amount { get; set; }
        public Supply fertilizer { get; set; }

        public RecommendingSupplyDto(long amount, Supply fertilizer)
        {
            this.amount = amount;
            this.fertilizer = fertilizer;
        }
    }
}
