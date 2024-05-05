using winery_backend.Activity.Interface;
using winery_backend.Vineyard;

namespace winery_backend.Activity
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public ICollection<Activity> GetAll()
        {
            return _activityRepository.GetAll();
        }

        public Activity GetById(int id)
        {
            return _activityRepository.GetById(id);
        }

        public ICollection<Activity> GetByParcelId(int parcelId)
        {
            return _activityRepository.GetByParcelId(parcelId);
        }

    }
}
