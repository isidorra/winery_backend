using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using winery_backend.Activity.Dto;
using winery_backend.Activity.Interface;
using winery_backend.Vineyard;
using winery_backend.Vineyard.Interface;

namespace winery_backend.Activity
{
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : Controller
    {
        private readonly IActivityService _activityService;
        private readonly IParcelService _parcelService;

        public ActivityController(IActivityService activityService, IParcelService parcelService)
        {
            this._activityService = activityService;
            this._parcelService = parcelService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var activities = _activityService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(activities);
        }

        [HttpPost("watering/recommendation")]
        public IActionResult RecommendWateringAmount(int parcelId)
        {
            var amount = _parcelService.RecommendWateringAmount(parcelId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(amount);
        }

        [HttpPost("add/watering")]
        public IActionResult AddWatering(WateringDto wateringDto)
        {
            if(_activityService.ScheduleWatering(wateringDto))
            {
                return Ok("Successful");
            }
            else
            {
                return BadRequest("Can't book watering of the parcel during that time");
            }
        }

        [HttpPost("harvesting/recommendation")]
        public IActionResult RecommendParcels(string grape)
        {
            ICollection<Parcel> parcels = _parcelService.GetByGrape(grape);
            if (!parcels.IsNullOrEmpty())
            {
                return Ok(parcels);
            }
            else
            {
                return BadRequest("No parcels with entered grape");
            }
        }

        [HttpPost("add/harvesting")]
        public IActionResult AddHarvesting(HarvestingDto harvestingDto)
        {
            Parcel parcel = _parcelService.GetById(harvestingDto.parcelId);
            if(parcel.Amount < harvestingDto.amount)
            {
                return BadRequest("Not enough grapes on the parcel");
            }
            
            if (_activityService.ScheduleHarvesting(harvestingDto))
            {
                return Ok("Successful");
            }
            else
            {
                return BadRequest("Can't book harvesting of the parcel during that time");
            }
        }


    }
}
