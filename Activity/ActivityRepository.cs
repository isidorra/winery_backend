using System.Collections.ObjectModel;
using winery_backend.Activity.Interface;

namespace winery_backend.Activity
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly DataContext _context;

        public ActivityRepository(DataContext Context)
        {
            _context = Context;
        }

        public bool Create(Activity activity)
        {
            _context.Add(activity);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<Activity> GetAll()
        {
            return _context.Activities.OrderBy(a => a.Id).ToList();
        }

        public Activity GetById(int id)
        {
            return _context.Activities.Where(a => a.Id.Equals(id)).FirstOrDefault();
        }

        public ICollection<Activity> GetByParcelId(int parcelId)
        {
            ICollection<Activity> allActivities = GetAll();
            ICollection<Activity> activitiesForParcel = new Collection<Activity> ();

            foreach (Activity activity in allActivities)
            {
                if (activity.Parcel.Id == parcelId)
                    activitiesForParcel.Add(activity);
            }

            return activitiesForParcel;
        }
    }
}
