using Microsoft.AspNetCore.Mvc;
using winery_backend.Invetory.Interface;

namespace winery_backend.Supplies
{

    [Route("api/supplies")]
    [ApiController]
    public class SupplyController : Controller
    {
        private readonly ISupplyService _supplyService;

        public SupplyController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var activities = _supplyService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(activities);
        }
    }
}
