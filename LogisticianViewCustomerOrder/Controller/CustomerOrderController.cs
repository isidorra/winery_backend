namespace winery_backend.LogisticianViewCustomerOrder.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;

    [Route("api/logistician/customerOrders")]
    [ApiController]
    public class CustomerOrderController : Controller
    {
        private readonly ICustomerOrderService _customerOrderService;

        public CustomerOrderController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        [HttpGet]
        public IActionResult GetAllActiveCustomerOrders()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<CustomerOrder> activeCustomerOrders = _customerOrderService.GetAllActiveCustomerOrders();

            // var 
            return Ok(activeCustomerOrders);
        }

    }
}
