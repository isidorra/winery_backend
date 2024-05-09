using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Interface
{
    public interface ICustomerOrderService
    {
        List<CustomerOrder> GetAllActiveCustomerOrders();
    }
}
