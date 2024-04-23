using Microsoft.AspNetCore.Mvc;

[Route("/api/city")]
[ApiController]
public class CityController : Controller {
    private readonly ICityService _cityService;

    public CityController(ICityService cityService) {
        _cityService = cityService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var cities = _cityService.GetAll();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(cities);
    }

}