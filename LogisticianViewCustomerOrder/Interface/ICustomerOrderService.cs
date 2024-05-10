using winery_backend.LogisticianViewCustomerOrder.Dto;
using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.LogisticianViewCustomerOrder.Repository;

namespace winery_backend.LogisticianViewCustomerOrder.Interface
{
    public interface ICustomerOrderService
    {
        List<CustomerOrder> GetAllActiveCustomerOrders();
        CustomerOrder FindCustomerOrderById(int id);
    }
}
