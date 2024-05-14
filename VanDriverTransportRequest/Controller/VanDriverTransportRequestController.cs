namespace winery_backend.VanDriverTransportRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.TransportRequest.Interface;
    using winery_backend.VanDriverTransportRequest.Dto;
    using winery_backend.ViewWarehouse.Interface;
    using winery_backend.WarehousemanPackingRequest.Dto;

    [Route("api/vandriver/transportRequests")]
    [ApiController]
    public class VanDriverTransportRequestController : Controller
    {
        private readonly ITransportRequestService _transportRequestService;
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IRealTimeOrderTrackingStatusService _realTimeOrderTrackingStatusService;
        private readonly ISectorService _sectorService;

        public VanDriverTransportRequestController(ITransportRequestService transportRequestService, ICustomerOrderService customerOrderService, IRealTimeOrderTrackingStatusService realTimeOrderTrackingStatusService, ISectorService sectorService)
        {
            _transportRequestService = transportRequestService;
            _customerOrderService = customerOrderService;
            _realTimeOrderTrackingStatusService = realTimeOrderTrackingStatusService;
            _sectorService = sectorService;
        }

        [HttpGet]
        public IActionResult GetAllTransportRequests(int vanDriverId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<TransportRequest.Models.TransportRequest> transportRequests = _transportRequestService.FindByVanDriverId(vanDriverId);

            List<VanDriverTransportRequestsViewDto> vanDriverTransportRequestsViewDtos = new List<VanDriverTransportRequestsViewDto>();

            foreach(TransportRequest.Models.TransportRequest transportRequest in transportRequests)
            {
                CustomerOrder customerOrder = _customerOrderService.FindCustomerOrderById(transportRequest.CustomerOrderId);

                string orderTrackingStatus = _realTimeOrderTrackingStatusService.FindStatusNameById(customerOrder.OrderTrackingStatusId);

                if(!orderTrackingStatus.Equals("delivered"))
                {
                    vanDriverTransportRequestsViewDtos.Add(new VanDriverTransportRequestsViewDto(transportRequest.TransportRequestId, orderTrackingStatus, transportRequest.PickUpDeadlineDate));
                }
            }

            return Ok(vanDriverTransportRequestsViewDtos);
        }

        [HttpGet("singleTransportRequest")]
        public IActionResult GetSingleTransportRequest(int id, string orderTrackingStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TransportRequest.Models.TransportRequest transportRequest = _transportRequestService.FindById(id);

            // treba da se promeni kada warehouseman odradi zahtev za pakovanje, da bude waiting for pick up, a ne packed, i onda ovde obrises packed
            if(orderTrackingStatus.Equals("waiting for pick up") || orderTrackingStatus.Equals("packed"))
            {
                WaitingForPickUpDto waitingForPickUpDto = new WaitingForPickUpDto(transportRequest.CustomerUsername, transportRequest.CustomerDeliveryAddress);
                return Ok(waitingForPickUpDto);
            }
            else if(orderTrackingStatus.Equals("ready for pick up"))
            {
                List<string> sectorNames = _sectorService.FindSectorsName(transportRequest.SectorIdsForPickUp);
                ReadyForPickUpDto readyForPickUpDto = new ReadyForPickUpDto(transportRequest.CustomerUsername, transportRequest.CustomerDeliveryAddress, sectorNames);

                return Ok(readyForPickUpDto);
            }
            else if(orderTrackingStatus.Equals("picked up"))
            {
                PickedUpDto pickedUpDto = new PickedUpDto(transportRequest.CustomerUsername, transportRequest.CustomerDeliveryAddress);
                return Ok(pickedUpDto);
            }
            else if(orderTrackingStatus.Equals("in transport"))
            {
                // ovde sam stao
                // kada ovo zavrsis, onda treba da proveris ispocetka svaki korak redom da li rade ovi if-ovi, tj. da li vracaju prave poruke, kada odradis migracije
            }

            return Ok("a");
        }

        [HttpPost("pickUpPackages")]
        public IActionResult PickUpPackages(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TransportRequest.Models.TransportRequest transportRequest = _transportRequestService.FindById(id);

            int newStatusId = _realTimeOrderTrackingStatusService.FindIdByStatusName("picked up");

            _customerOrderService.ChangeOrderStatus(transportRequest.CustomerOrderId, newStatusId);

            return Ok("ALL PACKAGES HAVE BEEN PICKED UP");
        }

        [HttpPost("transportPackages")]
        public IActionResult TransportPackages(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TransportRequest.Models.TransportRequest transportRequest = _transportRequestService.FindById(id);

            int newStatusId = _realTimeOrderTrackingStatusService.FindIdByStatusName("in transport");

            _customerOrderService.ChangeOrderStatus(transportRequest.CustomerOrderId, newStatusId);

            return Ok("THE TRANSPORT HAS STARTED");
        }
    }
}
