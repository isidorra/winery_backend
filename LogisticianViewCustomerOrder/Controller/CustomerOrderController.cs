namespace winery_backend.LogisticianViewCustomerOrder.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Dto;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.LogisticianViewCustomerOrder.Repository;
    using winery_backend.LogisticianViewCustomerOrder.Service;
    using winery_backend.ViewWarehouse.Interface;

    [Route("api/logistician/customerOrders")]
    [ApiController]
    public class CustomerOrderController : Controller
    {
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IRealTimeOrderTrackingStatusService _realTimeOrderTrackingStatusService;
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly ISectorService _sectorService;

        public CustomerOrderController(ICustomerOrderService customerOrderService, IRealTimeOrderTrackingStatusService realTimeOrderTrackingStatusService, IProductService productService, ICustomerService customerService, ISectorService sectorService)
        {
            _customerOrderService = customerOrderService;
            _realTimeOrderTrackingStatusService = realTimeOrderTrackingStatusService;
            _productService = productService;
            _customerService = customerService;
            _sectorService = sectorService;
        }

        [HttpGet]
        public IActionResult GetAllActiveCustomerOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<CustomerOrder> allActiveCustomerOrders = _customerOrderService.GetAllActiveCustomerOrders();

            List<LogisticianCustomerOrdersViewDto> allActiveCustomerOrdersDto =  new List<LogisticianCustomerOrdersViewDto>();

            foreach (var customerOrder in allActiveCustomerOrders)
            {
                LogisticianCustomerOrdersViewDto logisticianCustomerOrdersView = new LogisticianCustomerOrdersViewDto(customerOrder.CustomerOrderId, _realTimeOrderTrackingStatusService.FindStatusNameById(customerOrder.OrderTrackingStatusId), customerOrder.CustomerOrderDeliveryDeadline);
                allActiveCustomerOrdersDto.Add(logisticianCustomerOrdersView);
            }
 
            return Ok(allActiveCustomerOrdersDto);
        }

        [HttpGet("singleCustomerOrder")]
        public IActionResult GetSingleActiveCustomerOrder(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LogisticianSingleCustomerOrderViewDto logisticianSingleCustomerOrderViewDto = new LogisticianSingleCustomerOrderViewDto();

            CustomerOrder customerOrder = _customerOrderService.FindCustomerOrderById(id);
            Customer customer = _customerService.GetById(customerOrder.CustomerId);

            logisticianSingleCustomerOrderViewDto.CustomerOrderCreationTime = customerOrder.CustomerOrderCreationTime;

            List<Product> products = _productService.FindProductsByCustomerOrderId(customerOrder.ProductIds);
            List<ProductLogisticianDto> productLogisticianDtos = new List<ProductLogisticianDto>();

            int i = 0;

            foreach (Product product in products)
            {
                ProductLogisticianDto productLogisticianDto = new ProductLogisticianDto(product.ProductName, customerOrder.Quantities[i], _sectorService.FindSectorName(product.SectorId));
                productLogisticianDtos.Add(productLogisticianDto);
                i = i + 1;
            }

            logisticianSingleCustomerOrderViewDto.ProductsQuantities = productLogisticianDtos;
            logisticianSingleCustomerOrderViewDto.CustomerOrderPrice = customerOrder.CustomerOrderPrice;
            logisticianSingleCustomerOrderViewDto.CustomerUserName = customer.Username;
            logisticianSingleCustomerOrderViewDto.DeliveryAddress = customer.Street;

            return Ok(logisticianSingleCustomerOrderViewDto);
        }

    }
}
