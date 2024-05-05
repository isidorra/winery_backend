using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Watering : Activity
    {
        public long Amount { get; set; }
        public Watering(DateTime startDate, int parcelId, long amount) : base(Guid.NewGuid(), startDate, startDate.AddDays(1), false, ActivityType.Watering, parcelId)
        {
            Amount = amount;
        }
    }
}
