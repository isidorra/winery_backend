﻿using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;
using Microsoft.EntityFrameworkCore;

namespace winery_backend.LogisticianViewCustomerOrder.Repository
{
    public class CustomerOrderRepository : ICustomerOrderRepository
    {
        private readonly DataContext _context;
        public CustomerOrderRepository(DataContext context)
        {
            _context = context;
        }

        public List<CustomerOrder> GetAllActiveCustomerOrders()
        {
            return _context.CustomerOrders.OrderBy(x => x.CustomerOrderDeliveryDeadline).ToList();
        }

        public CustomerOrder FindCustomerOrderById(int id)
        {
            return _context.CustomerOrders.First(x => x.CustomerOrderId == id);
        }

        public void ChangeOrderStatus(int customerOrderId, int newStatusId)
        {
            _context.CustomerOrders.Where(x => x.CustomerOrderId == customerOrderId).First().OrderTrackingStatusId = newStatusId;
            _context.SaveChanges();
        }
    }
}
