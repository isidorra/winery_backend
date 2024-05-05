using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Harvesting : Activity
    {
        public long Amount { get; set; }
        public Harvesting(DateTime startDate, DateTime endDate, bool isCompleted, ActivityType activityType, int parcelId, long amount) : base(Guid.NewGuid(), startDate, endDate, isCompleted, activityType, parcelId)
        {
            Amount = amount;
        }


    }
}
