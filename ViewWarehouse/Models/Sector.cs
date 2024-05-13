namespace winery_backend.ViewWarehouse.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string? SectorName { get; set; }
        public string? SectorImage { get; set; }
        public int WarehouseId { get; set; }
        public int WarehousemanId {  get; set; }

        public Sector()
        {

        }

        public Sector(int sectorId, string? sectorName, string? sectorImage, int warehouseId, int warehousemanId)
        {
            SectorId = sectorId;
            SectorName = sectorName;
            SectorImage = sectorImage;
            WarehouseId = warehouseId;
            WarehousemanId = warehousemanId;
        }
    }
}
