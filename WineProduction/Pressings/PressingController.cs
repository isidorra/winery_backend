using Microsoft.AspNetCore.Mvc;
using winery_backend.WineProduction.Fermentations.Dto;
using winery_backend.WineProduction.Pressings.Dto;

namespace winery_backend.WineProduction.Pressings
{
    [Route("api/fermentation")]
    [ApiController]
    public class PressingController : Controller
    {
        private readonly PressingService _pressingService;
        public PressingController(PressingService pressingService)
        {
            _pressingService = pressingService;
        }

        [HttpPost("add")]
        public IActionResult AddPressing(PressingDto pressingDto)
        {
            if (_pressingService.Create(pressingDto))
            {
                return Ok("Successful");
            }
            else
            {
                return BadRequest("Can't book pressing");
            }
        }


    }
}
