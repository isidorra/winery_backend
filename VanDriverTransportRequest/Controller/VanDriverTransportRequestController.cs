namespace winery_backend.VanDriverTransportRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
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

            if(orderTrackingStatus.Equals("waiting for pick up"))
            {
                WaitingForPickUpDto waitingForPickUpDto = new WaitingForPickUpDto(transportRequest.CustomerUsername, transportRequest.CustomerDeliveryAddress);
                return Ok(waitingForPickUpDto);
            }
            else if(orderTrackingStatus.Equals("ready for pick up"))
            {
                List<string> sectorNames = new List<string>();
                sectorNames = _sectorService.FindSectorsName(transportRequest.SectorIdsForPickUp);
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
                InTransportDto inTransportDto = new InTransportDto(transportRequest.CustomerUsername, transportRequest.CustomerDeliveryAddress);
                return Ok(inTransportDto);
            }

            return BadRequest("Greska");
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

        [HttpPost("deliverPackages")]
        public IActionResult DeliverPackages(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TransportRequest.Models.TransportRequest transportRequest = _transportRequestService.FindById(id);

            int newStatusId = _realTimeOrderTrackingStatusService.FindIdByStatusName("delivered");

            _customerOrderService.ChangeOrderStatus(transportRequest.CustomerOrderId, newStatusId);

            return Ok("THE ORDER HAS BEEN SUCCESSFULLY DELIVERED TO THE CUSTOMER");
        }
    }
}
