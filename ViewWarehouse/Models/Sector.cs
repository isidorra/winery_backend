namespace winery_backend.ViewWarehouse.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? SectorImage { get; set; }
        public int WarehouseId { get; set; }
    }
}
