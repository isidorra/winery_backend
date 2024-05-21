﻿using System.Collections.Generic;
using winery_backend.Activity.Dto;
using winery_backend.Activity.Interface;
using winery_backend.Vineyard;
using winery_backend.Supplies;
using Supplies;
using winery_backend.Supplies.Interface;


namespace winery_backend.Activity
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ISupplyRepository _supplyRepository;

        public ActivityService(IActivityRepository activityRepository, ISupplyRepository supplyRepository)
        {
            _activityRepository = activityRepository;
            _supplyRepository = supplyRepository;
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

        public bool ScheduleFertilization(SupplyingDto fertilizationDto)
        {
            ICollection<Activity> allActivities = _activityRepository.GetAll();
            foreach (Activity activity in allActivities)
            {
                if (fertilizationDto.startDate >= activity.StartDate && fertilizationDto.startDate <= activity.EndDate && activity.Parcel.Id == fertilizationDto.parcelId)
                {
                    return false;
                }
            }

            Fertilization newFertilization = new Fertilization(fertilizationDto.startDate, fertilizationDto.parcelId, fertilizationDto.amount, fertilizationDto.supplyId);
            Supply usedFertilizer = _supplyRepository.GetById(fertilizationDto.supplyId);
            usedFertilizer.Amount -= fertilizationDto.amount;
            _supplyRepository.Update(usedFertilizer);
            return _activityRepository.Create(newFertilization);

        }

        public bool ScheduleHarvesting(HarvestingDto harvestingDto)
        {
            ICollection<Activity> allActivities = _activityRepository.GetAll();
            foreach (Activity activity in allActivities)
            {
                if (harvestingDto.startDate >= activity.StartDate && harvestingDto.startDate <= activity.EndDate && activity.Parcel.Id == harvestingDto.parcelId)
                {
                    return false;
                }
            }

            Harvesting newHarvesting = new Harvesting(harvestingDto.startDate, harvestingDto.parcelId, harvestingDto.amount);
            return _activityRepository.Create(newHarvesting);
        }

        public bool SchedulePesticideControl(SupplyingDto pesticideDto)
        {
            ICollection<Activity> allActivities = _activityRepository.GetAll();
            foreach (Activity activity in allActivities)
            {
                if (pesticideDto.startDate >= activity.StartDate && pesticideDto.startDate <= activity.EndDate && activity.Parcel.Id == pesticideDto.parcelId)
                {
                    return false;
                }
            }

            PesticideControl newPesticideControl = new PesticideControl(pesticideDto.startDate, pesticideDto.parcelId, pesticideDto.amount, pesticideDto.supplyId);
            Supply usedPesticide = _supplyRepository.GetById(pesticideDto.supplyId);
            usedPesticide.Amount -= pesticideDto.amount;
            _supplyRepository.Update(usedPesticide);
            return _activityRepository.Create(newPesticideControl);
        }

        public bool ScheduleWatering(WateringDto wateringDto)
        {
            ICollection<Activity> allActivities = _activityRepository.GetAll();
            foreach (Activity activity in allActivities)
            {
                if (wateringDto.startDate >= activity.StartDate && wateringDto.startDate <= activity.EndDate && activity.Parcel.Id == int.Parse(wateringDto.parcelId))
                {
                    return false;
                }
            }

            Watering newWatering = new Watering(wateringDto.startDate, int.Parse(wateringDto.parcelId), wateringDto.amount);
            return _activityRepository.Create(newWatering);

        }
    }
}
