﻿using winery_backend.LogisticianViewCustomerOrder.Interface;
using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        
        public List<Product> FindProductsByCustomerOrderId(List<int> productIds)
        {
            List<Product> products = new List<Product>();

            foreach (var productId in productIds)
            {
                Product product = _context.Products.First(x => x.ProductId == productId);
                products.Add(product);
            }
            return products;
        }
    }
}
