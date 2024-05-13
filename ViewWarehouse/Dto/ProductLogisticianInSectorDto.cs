namespace winery_backend.ViewWarehouse.Dto
{
    public class ProductLogisticianInSectorDto
    {
        public string ProductName { get; set; }
        public int? Quantity { get; set; }

        public ProductLogisticianInSectorDto()
        {

        }

        public ProductLogisticianInSectorDto(string productName, int? quantity)
        {
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
