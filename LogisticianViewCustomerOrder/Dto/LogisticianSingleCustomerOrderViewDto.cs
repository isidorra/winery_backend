using winery_backend.LogisticianViewCustomerOrder.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Dto
{
    public class LogisticianSingleCustomerOrderViewDto
    {
        public DateTime CustomerOrderCreationTime {  get; set; }
        public List<ProductLogisticianDto> ProductsQuantities { get; set; }
        public decimal CustomerOrderPrice { get; set; }
        public string CustomerUserName {  get; set; }
        public string DeliveryAddress { get; set; }

        public LogisticianSingleCustomerOrderViewDto()
        {

        }

        public LogisticianSingleCustomerOrderViewDto(DateTime customerOrderCreationTime, List<ProductLogisticianDto> productsQuantities, decimal customerOrderPrice, string customerUserName, string deliveryAddress)
        {
            CustomerOrderCreationTime = customerOrderCreationTime;
            ProductsQuantities = productsQuantities;
            CustomerOrderPrice = customerOrderPrice;
            CustomerUserName = customerUserName;
            DeliveryAddress = deliveryAddress;
        }

        public LogisticianSingleCustomerOrderViewDto(DateTime customerOrderCreationTime, List<ProductLogisticianDto> productsQuantities, decimal customerOrderPrice)
        {
            CustomerOrderCreationTime = customerOrderCreationTime;
            ProductsQuantities = productsQuantities; CustomerOrderPrice = customerOrderPrice;
            CustomerOrderPrice = customerOrderPrice;
            CustomerUserName = "-";
            DeliveryAddress = "-";
        }
    }
}
