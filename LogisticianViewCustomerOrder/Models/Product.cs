using winery_backend.ViewWarehouse.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string Photo { get; set; }
        public string WineSort { get; set; }
        public decimal PackagingSize { get; set; }
        public int ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public int SectorId { get; set; }

        public Product()
        {

        }

        public Product(int productId, string productName, string productDescription, string photo, string wineSort, decimal packagingSize, int productPrice, int productQuantity, decimal alcoholPercentage, int sectorId)
        {
            ProductId = productId;
            ProductName = productName;
            ProductDescription = productDescription;
            Photo = photo;
            WineSort = wineSort;
            PackagingSize = packagingSize;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
            AlcoholPercentage = alcoholPercentage;
            SectorId = sectorId;
        }
    }
}
