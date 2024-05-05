﻿using winery_backend.Activity.Dto;

namespace winery_backend.Activity.Interface
{
    public interface IActivityService
    {
        ICollection<Activity> GetAll();
        ICollection<Activity> GetByParcelId(int parcelId);
        Activity GetById(int id);
        bool ScheduleWatering(WateringDto wateringDto);
    }
}
