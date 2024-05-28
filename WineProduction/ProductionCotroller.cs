using Microsoft.AspNetCore.Mvc;
using winery_backend.WineProduction.Fermentations.Interface;

namespace winery_backend.WineProduction
{
    [Route("api/production")]
    [ApiController]
    public class ProductionCotroller : Controller
    {
        private readonly IFermentationService _fermentationService;

        public ProductionCotroller(IFermentationService fermentationService)
        {
            _fermentationService = fermentationService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var activities = _fermentationService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(activities);
        }
    }
}
