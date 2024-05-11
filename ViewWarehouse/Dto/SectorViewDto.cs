using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Dto
{
    public class SectorViewDto
    {
        public string SectorName { get; set; }
        public string SectorImage { get; set; }
        public string WarehousemanName { get; set; }
        public List<ProductLogisticianInSectorDto> ProductLogisticianInSectorDtos { get; set; }

        public SectorViewDto()
        {

        }

        public SectorViewDto(string sectorName, string sectorImage, string warehousemanName, List<ProductLogisticianInSectorDto> productLogisticianInSectorDtos)
        {
            SectorName = sectorName;
            SectorImage = sectorImage;
            WarehousemanName = warehousemanName;
            ProductLogisticianInSectorDtos = productLogisticianInSectorDtos;
        }
    }
}
