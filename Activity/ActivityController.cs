using Microsoft.AspNetCore.Mvc;
using winery_backend.Activity.Dto;
using winery_backend.Activity.Interface;
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
            _activityService.ScheduleWatering(wateringDto);
            return null;
        }
    }
}
