namespace winery_backend.TransportRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.PackingRequest.Interface;
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
        private readonly IPackingRequestService _packingRequestService;

        public TransportRequestController(ITransportRequestService transportRequestService, IEmployeeService employeeService, ICustomerOrderService customerOrderService, ICustomerService customerService, ISectorService sectorService, IPackingRequestService packingRequestService)
        {
            _transportRequestService = transportRequestService;
            _employeeService = employeeService;
            _customerOrderService = customerOrderService;
            _customerService = customerService;
            _sectorService = sectorService;
            _packingRequestService = packingRequestService;
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

            if((customerOrder.CustomerOrderDeliveryDeadline - pickUpPackagesDeadlineDate).TotalDays < 3 || !validDate(customerOrderId, pickUpPackagesDeadlineDate))
            {
                return BadRequest("Transport mora da se zakaze najkasnije 3 dana do isporuke porudzbine");
            }

            Customer customer = _customerService.GetById(customerOrderId);

            List<int> sectorIds = _sectorService.FindSectorIds(sectorNames);

            int vanDriverId = _employeeService.FindVanDriverId(vanDriverName);

            TransportRequest.Models.TransportRequest transportRequest = new TransportRequest.Models.TransportRequest(_transportRequestService.FindLastId(), pickUpPackagesDeadlineDate, DateTime.Now, customerOrder.CustomerOrderDeliveryDeadline, sectorIds, customer.Username, customer.Street, customerOrderId, vanDriverId);

            if (_transportRequestService.CreateTransportRequest(transportRequest))
            {
                return Ok("successfully");
            }

            return BadRequest("Vec je napravljen ovaj transport request");
        }

        private bool validDate(int customerOrderId, DateTime pickUpPackagesDeadlineDate)
        {
            List<DateTime> dateTimes = _packingRequestService.FindPackingRequestDeadlineDateByCustomerOrderId(customerOrderId);

            foreach(DateTime date in dateTimes)
            {
                if ((pickUpPackagesDeadlineDate - date).TotalDays < 1)
                {
                    return false;
                }
            }
            return true;
        }


        [HttpPost("edit")]
        public IActionResult EditTransportRequest(DateTime pickUpPackagesDeadlineDate, int customerOrderId, string vanDriverName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CustomerOrder customerOrder = _customerOrderService.FindCustomerOrderById(customerOrderId);

            if((customerOrder.CustomerOrderDeliveryDeadline - pickUpPackagesDeadlineDate).TotalDays < 3 || !validDate(customerOrderId, pickUpPackagesDeadlineDate))
            {
                return BadRequest("Transport mora da se zakaze najkasnije 3 dana do isporuke porudzbine");
            }

            int vanDriverId = _employeeService.FindVanDriverId(vanDriverName);

            _transportRequestService.Update(customerOrderId, vanDriverId, pickUpPackagesDeadlineDate);

            return Ok("successfully");
        }

        [HttpPost("cancel")]
        public IActionResult CancelTransportRequest(int customerOrderId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _transportRequestService.Delete(customerOrderId);

            return Ok("successfully");
        }
    }
}
