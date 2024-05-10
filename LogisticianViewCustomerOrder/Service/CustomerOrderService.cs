using winery_backend.LogisticianViewCustomerOrder.Dto;
using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Service
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _customerOrderRepository;
        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository)
        {
            _customerOrderRepository = customerOrderRepository;
        }

        public List<CustomerOrder> GetAllActiveCustomerOrders()
        {
            return _customerOrderRepository.GetAllActiveCustomerOrders();
        }

        public CustomerOrder FindCustomerOrderById(int id)
        {
            return _customerOrderRepository.FindCustomerOrderById(id);
        }
    }
}
