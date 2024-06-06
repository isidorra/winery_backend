using Microsoft.AspNetCore.Mvc;
using winery_backend.WineProduction.Fermentations.Dto;
using winery_backend.WineProduction.Pressings.Dto;
using winery_backend.WineProduction.Pressings.Interface;

namespace winery_backend.WineProduction.Pressings
{
    [Route("api/pressing")]
    [ApiController]
    public class PressingController : Controller
    {
        private readonly IPressingService _pressingService;
        public PressingController(IPressingService pressingService)
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
