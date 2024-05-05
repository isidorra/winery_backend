using System.Collections.Generic;
using winery_backend.Activity.Dto;
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

        public bool ScheduleWatering(WateringDto wateringDto)
        {
            ICollection<Activity> allActivities = _activityRepository.GetAll();
            foreach (Activity activity in allActivities)
            {
                if (wateringDto.startDate >= activity.StartDate && wateringDto.startDate <= activity.EndDate)
                {
                    return false;
                }
            }

            long longAmount;
            long.TryParse(wateringDto.amount, out longAmount);
            Watering newWatering = new Watering(wateringDto.startDate, int.Parse(wateringDto.parcelId), longAmount);
            return _activityRepository.Create(newWatering);

        }
    }
}
