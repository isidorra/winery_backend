using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Interface
{
    public interface ICustomerOrderRepository
    {
        List<CustomerOrder> GetAllActiveCustomerOrders();
        CustomerOrder FindCustomerOrderById(int id);
        void ChangeOrderStatus(int customerOrderId, int newStatusId);
    }
}
