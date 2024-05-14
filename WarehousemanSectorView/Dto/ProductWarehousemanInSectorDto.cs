namespace winery_backend.WarehousemanSectorView.Dto
{
    public class ProductWarehousemanInSectorDto
    {
        public string ProductName { get; set; }
        public int? Quantity { get; set; }

        public ProductWarehousemanInSectorDto()
        {

        }

        public ProductWarehousemanInSectorDto(string productName, int? quantity)
        {
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
