namespace winery_backend.PackingRequest.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using winery_backend.LogisticianViewCustomerOrder.Dto;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.PackingRequest.Interface;
    using winery_backend.ViewWarehouse.Interface;

    [Route("api/logistician/packingRequest")]
    [ApiController]
    public class PackingRequestController : Controller
    {
        private readonly IPackingRequestService _packingRequestService;
        private readonly ISectorService _sectorService;
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IProductService _productService;
        private readonly IRealTimeOrderTrackingStatusService _realTimeOrderTrackingStatusService;

        public PackingRequestController(IPackingRequestService packingRequestService, ISectorService sectorService, ICustomerOrderService customerOrderService, IProductService productService, IRealTimeOrderTrackingStatusService realTimeOrderTrackingStatusService)
        {
            _packingRequestService = packingRequestService;
            _sectorService = sectorService;
            _customerOrderService = customerOrderService;
            _productService = productService;
            _realTimeOrderTrackingStatusService = realTimeOrderTrackingStatusService;
        }

        [HttpPost]
        public IActionResult GetAllPackingRequestSectors(List<int> sectorIds, int customerOrderId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<int> requiredSectorIds = _packingRequestService.FindAllUnassignedSectors(sectorIds, customerOrderId);

            List<string> sectors = _sectorService.FindSectorsName(requiredSectorIds);

            return Ok(sectors);
        }

        [HttpPost("create")]
        public IActionResult CreatePackingRequest(string sectorName, DateTime packingDeadlineDate, int customerOrderId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CustomerOrder customerOrder = _customerOrderService.FindCustomerOrderById(customerOrderId);

            int sectorId = _sectorService.FindSectorId(sectorName);


            List<int> products = new List<int>();
            List<int> quantities = new List<int>();

            int i = 0;

            foreach (int id in customerOrder.ProductIds)
            {
                if(_productService.FindProductSectorIdByProductId(id) == sectorId)
                {
                    products.Add(id);
                    quantities.Add(customerOrder.Quantities[i]);
                }

                i = i + 1;
            }

            if(_packingRequestService.CreatePackingRequest(sectorId, packingDeadlineDate, products, quantities, customerOrderId))
            {
                int newStatusId = _realTimeOrderTrackingStatusService.FindIdByStatusName("distributed");
                _customerOrderService.ChangeOrderStatus(customerOrderId, newStatusId);
                return Ok("successfully");
            };

            return BadRequest("Vec je napravljen ovaj packing request");
        }
    }
}
