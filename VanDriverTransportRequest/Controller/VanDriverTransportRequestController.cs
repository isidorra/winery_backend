namespace winery_backend.VanDriverTransportRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.TransportRequest.Interface;

    [Route("api/vandriver/transportRequests")]
    [ApiController]
    public class VanDriverTransportRequestController : Controller
    {
        private readonly ITransportRequestService _transportRequestService;

        public VanDriverTransportRequestController(ITransportRequestService transportRequestService)
        {
            _transportRequestService = transportRequestService;
        }
    }
}
