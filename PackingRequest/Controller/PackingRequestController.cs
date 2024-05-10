namespace winery_backend.PackingRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.PackingRequest.Interface;

    [Route("api/logistician/packingRequest")]
    [ApiController]
    public class PackingRequestController : Controller
    {
        private readonly IPackingRequestService _packingRequestService;

        public PackingRequestController(IPackingRequestService packingRequestService)
        {
            _packingRequestService = packingRequestService;
        }

        [HttpGet]
        public IActionResult GetAllPackingRequestSectors(List<int> sectorIds)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            // var 
            return Ok("");
        }
    }
}
