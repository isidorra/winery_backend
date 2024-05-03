using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public ActivityType ActivityType { get; set; }
        public Parcel Parcel { get; set; }

        public Activity(int id, DateTime startDate, DateTime endDate, bool isCompleted, ActivityType activityType, Parcel parcel)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            IsCompleted = isCompleted;
            ActivityType = activityType;
            Parcel = parcel;
        }
    }
}
