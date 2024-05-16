namespace winery_backend.WarehousemanPackingRequest.Dto
{
    public class ProductWarehousemanDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        public ProductWarehousemanDto()
        {

        }

        public ProductWarehousemanDto(string productName, int quantity)
        {
            ProductName = productName;
            Quantity = quantity;
        }
    }
}
