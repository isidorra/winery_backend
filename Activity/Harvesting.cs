using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Harvesting : Activity
    {
        public long Amount { get; set; }
        public Harvesting(int id, DateTime startDate, DateTime endDate, bool isCompleted, ActivityType activityType, Parcel parcel, long amount) : base(id, startDate, endDate, isCompleted, activityType, parcel)
        {
            Amount = amount;
        }


    }
}
