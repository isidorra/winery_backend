using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Activity
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public ActivityType ActivityType { get; set; }
        public int ParcelId { get; set; }
        public virtual Parcel Parcel { get; set; }

        public Activity()
        {

        }

        public Activity(Guid id, DateTime startDate, DateTime endDate, bool isCompleted, ActivityType activityType, int parcelId)
        {
            Id = Guid.NewGuid();
            StartDate = startDate;
            EndDate = endDate;
            IsCompleted = isCompleted;
            ActivityType = activityType;
            ParcelId = parcelId;
        }
    }
}
