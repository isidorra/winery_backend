using Microsoft.AspNetCore.Mvc;
using winery_backend.Grapes.Interface;
using winery_backend.WineProduction.Fermentations;
using winery_backend.WineProduction.Fermentations.Interface;

namespace winery_backend.Grapes
{
    [Route("api/grape")]
    [ApiController]
    public class GrapeController : Controller
    {
        private readonly IGrapeService _grapeService;

        public GrapeController(IGrapeService grapeService)
        {
            _grapeService = grapeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var grapes = _grapeService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(grapes);
        }
    }
}
