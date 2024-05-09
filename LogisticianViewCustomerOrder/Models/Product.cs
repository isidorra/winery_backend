using winery_backend.ViewWarehouse.Models;

namespace winery_backend.LogisticianViewCustomerOrder.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? Photo { get; set; }
        public string? WineSort { get; set; }
        public decimal? PackagingSize { get; set; }
        public int? ProductPrice { get; set; }
        public decimal? AlcoholPercentage { get; set; }
        public int? SectorId { get; set; }
        //public Sector? Sector { get; set; }

    }
}
