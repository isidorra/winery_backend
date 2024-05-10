namespace winery_backend.LogisticianViewCustomerOrder.Dto
{
    public class ProductLogisticianDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string SectorName { get; set; }

        public ProductLogisticianDto()
        {

        }

        public ProductLogisticianDto(string productName, int quantity, string sectorName)
        {
            ProductName = productName;
            Quantity = quantity;
            SectorName = sectorName;
        }
    }
}
