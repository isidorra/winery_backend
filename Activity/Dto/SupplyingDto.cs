namespace winery_backend.Activity.Dto
{
    public class SupplyingDto
    {
        public int parcelId { get; set; }
        public DateTime startDate { get; set; }
        public long amount { get; set; }
        public int supplyId { get; set; }

        public SupplyingDto(int parcelId, DateTime startDate, long amount, int supplyId)
        {
            this.parcelId = parcelId;
            this.startDate = startDate;
            this.amount = amount;
            this.supplyId = supplyId;
        }
    }
}
