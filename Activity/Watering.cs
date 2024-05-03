using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Watering : Activity
    {
        public Watering(int id, DateTime startDate, DateTime endDate, bool isCompleted, ActivityType activityType, Parcel parcel) : base(id, startDate, endDate, isCompleted, activityType, parcel)
        {

        }
    }
}
