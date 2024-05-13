namespace winery_backend.ViewWarehouse.Dto
{
    public class SectorDto
    {
        public string SectorName { get; set; }
        public string WarehousemanName { get; set; }

        public SectorDto()
        {

        }

        public SectorDto(string sectorName, string warehousemanName)
        {
            SectorName = sectorName;
            WarehousemanName = warehousemanName;
        }
    }
}
