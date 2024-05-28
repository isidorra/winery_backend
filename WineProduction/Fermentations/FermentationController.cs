using Microsoft.AspNetCore.Mvc;
using winery_backend.Activity.Dto;
using winery_backend.WineProduction.Fermentations.Dto;
using winery_backend.WineProduction.Fermentations.Interface;

namespace winery_backend.WineProduction.Fermentations
{
    [Route("api/fermentation")]
    [ApiController]
    public class FermentationController : Controller
    {
        private readonly IFermentationService _fermentationService;

        public FermentationController(IFermentationService fermentationService)
        {
            _fermentationService = fermentationService;
            _fermentationService.UpdateFinishedFertilizations();
        }

        [HttpPost("add")]
        public IActionResult AddFermentation(FermentationDto fermentationDto)
        {
            if (_fermentationService.Create(fermentationDto))
            {
                return Ok("Successful");
            }
            else
            {
                return BadRequest("Can't book fermentation");
            }
        }
    }
}
