namespace winery_backend.WarehousemanSectorView.Dto
{
    public class SingleProductSectorDto
    {
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
        public decimal PackagingSize { get; set; }
        public double? ProductPrice { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public string ProductPhoto { get; set; }

        public SingleProductSectorDto()
        {

        }

        public SingleProductSectorDto(string productName, string productCategoryName, decimal packagingSize, double? productPrice, decimal alcoholPercentage, string productPhoto)
        {
            ProductName = productName;
            ProductCategoryName = productCategoryName;
            PackagingSize = packagingSize;
            ProductPrice = productPrice;
            AlcoholPercentage = alcoholPercentage;
            ProductPhoto = productPhoto;
        }
    }
}
