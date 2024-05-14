namespace winery_backend.WarehousemanPackingRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Service;
    using winery_backend.PackingRequest.Interface;
    using winery_backend.ViewWarehouse.Interface;
    using winery_backend.WarehousemanPackingRequest.Dto;

    [Route("api/warehouseman/packingRequests")]
    [ApiController]
    public class WarehousemanPackingRequestController : Controller
    {
        private readonly IPackingRequestService _packingRequestService;
        private readonly ISectorService _sectorService;
        private readonly IProductService _productService;
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IRealTimeOrderTrackingStatusService _realTimeOrderTrackingStatusService;

        public WarehousemanPackingRequestController(IPackingRequestService packingRequestService, ISectorService sectorService, IProductService productService, ICustomerOrderService customerOrderService, IRealTimeOrderTrackingStatusService realTimeOrderTrackingStatusService)
        {
            _packingRequestService = packingRequestService;
            _sectorService = sectorService;
            _productService = productService;
            _customerOrderService = customerOrderService;
            _realTimeOrderTrackingStatusService = realTimeOrderTrackingStatusService;
        }

        [HttpGet]
        public IActionResult GetAllPackingRequests(int warehousemanId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int sectorId = _sectorService.FindSectorIdByWarehousemanId(warehousemanId);

            List<int> unpackedPackingRequestIds = _packingRequestService.FindUnpackedIdsBySectorId(sectorId);

            List<WarehousemanPackingRequestsViewDto> warehousemanPackingRequestsViewDtos = _packingRequestService.FindWarehousemanActivePackingRequests(unpackedPackingRequestIds);

            return Ok(warehousemanPackingRequestsViewDtos);
        }

        [HttpGet("singlePackingRequest")]
        public IActionResult GetSinglePackingRequest(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PackingRequest.Models.PackingRequest packingRequest = _packingRequestService.FindPackingRequestById(id);

            if(packingRequest.Packed == true)
            {
                return BadRequest("Ovaj zahtev za pakovanje je zavrsen");
            }

            List<ProductWarehousemanDto> productWarehousemanDtos = new List<ProductWarehousemanDto>();

            int i = 0;

            foreach(int packingRequestProductId in packingRequest.PackingRequestProductIds)
            {
                productWarehousemanDtos.Add(new ProductWarehousemanDto(_productService.FindProductNameById(packingRequestProductId), packingRequest.PackingRequestQuantities[i]));
                i = i + 1;
            }

            WarehousemanSinglePackingRequestViewDto warehousemanSinglePackingRequestViewDto = new WarehousemanSinglePackingRequestViewDto(id, packingRequest.PackingRequestCreationDate, productWarehousemanDtos);

            return Ok(warehousemanSinglePackingRequestViewDto);
        }

        [HttpPost("packPackingRequest")]
        public IActionResult PackPackingRequest(int packingRequestId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PackingRequest.Models.PackingRequest packingRequest = _packingRequestService.FindPackingRequestById(packingRequestId);

            if (packingRequest.Packed == true)
            {
                return BadRequest("Ovaj zahtev za pakovanje je zavrsen");
            }

            List<int> quantities = new List<int>();

            foreach(int quantity in packingRequest.PackingRequestQuantities)
            {
                quantities.Add(quantity);
            }

            int i = 0;

            foreach(int productId in packingRequest.PackingRequestProductIds)
            {
                _productService.UpdateProductQuantity(productId, quantities[i]);
                i = i + 1;
            }

            _packingRequestService.UpdatePacked(packingRequest);

            int customerOrderId = _packingRequestService.FindCustomerOrderIdById(packingRequestId);

            if(_packingRequestService.IsAllPacked(customerOrderId))
            {
                int newStatusId = _realTimeOrderTrackingStatusService.FindIdByStatusName("ready for pick up");
                _customerOrderService.ChangeOrderStatus(customerOrderId, newStatusId);
            }
            else
            {
                int newStatusId = _realTimeOrderTrackingStatusService.FindIdByStatusName("packed");
                _customerOrderService.ChangeOrderStatus(customerOrderId, newStatusId);
            }

            return Ok("PACKING REQUEST HAS BEEN DONE");
        }
    }
}
