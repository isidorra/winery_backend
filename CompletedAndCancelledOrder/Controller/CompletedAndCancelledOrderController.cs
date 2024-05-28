

namespace winery_backend.CompletedAndCancelledOrder.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.Machines.Interface;

    [Route("api/logistician/completedAndCancelledOrders")]
    [ApiController]
    public class CompletedAndCancelledOrderController : Controller
    {
        private readonly ICustomerOrderService _customerOrderService;
        private readonly IMachineOrderService _machineOrderService;

    }
}
