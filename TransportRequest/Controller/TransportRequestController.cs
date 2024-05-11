namespace winery_backend.TransportRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.Services;
    using winery_backend.TransportRequest.Interface;
    using winery_backend.ViewWarehouse.Interface;

    [Route("api/logistician/transportRequest")]
    [ApiController]
    public class TransportRequestController : Controller
    {
        private readonly ITransportRequestService _transportRequestService;
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerOrderService _customerOrderService;
        private readonly ICustomerService _customerService;
        private readonly ISectorService _sectorService;

        public TransportRequestController(ITransportRequestService transportRequestService, IEmployeeService employeeService, ICustomerOrderService customerOrderService, ICustomerService customerService, ISectorService sectorService)
        {
            _transportRequestService = transportRequestService;
            _employeeService = employeeService;
            _customerOrderService = customerOrderService;
            _customerService = customerService;
            _sectorService = sectorService;
        }

        [HttpGet]
        public IActionResult GetAllTransportRequestVanDrivers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<string> vanDriverNames = _employeeService.FindAllVanDriverNames();

            return Ok(vanDriverNames);
        }

        [HttpPost("create")]
        public IActionResult CreateTransportRequest(List<string> sectorNames, DateTime pickUpPackagesDeadlineDate, int customerOrderId, string vanDriverName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CustomerOrder customerOrder = _customerOrderService.FindCustomerOrderById(customerOrderId);

            Customer customer = _customerService.GetById(customerOrderId);

            List<int> sectorIds = _sectorService.FindSectorIds(sectorNames);

            int vanDriverId = _employeeService.FindVanDriverId(vanDriverName);

            TransportRequest.Models.TransportRequest transportRequest = new TransportRequest.Models.TransportRequest(_transportRequestService.FindLastId(), pickUpPackagesDeadlineDate, DateTime.Now, customerOrder.CustomerOrderDeliveryDeadline, sectorIds, customer.Username, customer.Street, customerOrderId, vanDriverId);

            if (_transportRequestService.CreateTransportRequest(transportRequest))
            {
                return Ok("successfully");
            };

            return BadRequest("Vec je napravljen ovaj transport request");
        }
    }
}
