namespace winery_backend.Activity.Dto
{
    public class HarvestingDto
    {
        public int parcelId;
        public DateTime startDate;
        public long amount;

        public HarvestingDto(int parcelId, DateTime startDate, long amount)
        {
            this.parcelId = parcelId;
            this.startDate = startDate;
            this.amount = amount;
        }
    }
}
