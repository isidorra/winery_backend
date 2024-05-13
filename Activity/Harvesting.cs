using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Harvesting : Activity
    {
        public long Amount { get; set; }
        public Harvesting() { }
        public Harvesting(DateTime startDate, int parcelId, long amount) : base(Guid.NewGuid(), startDate, startDate.AddDays(Convert.ToInt32(amount / 800)), false, ActivityType.Harvest, parcelId)
        {
            Amount = amount;
        }


    }
}
