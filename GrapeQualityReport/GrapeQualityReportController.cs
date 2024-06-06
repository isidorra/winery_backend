using Microsoft.AspNetCore.Mvc;
using winery_backend.GrapeQualityReport.Interface;

namespace winery_backend.GrapeQualityReport
{
    [Route("api/grape/report")]
    [ApiController]
    public class GrapeQualityReportController : Controller
    {
        private readonly IGrapeQualityReportService _grapeQualityReportService;

        public GrapeQualityReportController(IGrapeQualityReportService grapeQualityReportService)
        {
            _grapeQualityReportService = grapeQualityReportService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reports = _grapeQualityReportService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reports);
        }
    }
}
