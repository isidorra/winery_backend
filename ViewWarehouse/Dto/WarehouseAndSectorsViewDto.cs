using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Dto
{
    public class WarehouseAndSectorsViewDto
    {
        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }
        public int NumberOfWarehouseWorkers { get; set; }
        public int NumberOfVanDrivers { get; set; }
        public decimal WarehouseArea { get; set; }
        public int NumberOfSectors { get; set; }
        public string WarehouseImage { get; set; }
        public List<SectorDto> SectorDtos { get; set; }

        public WarehouseAndSectorsViewDto()
        {

        }

        public WarehouseAndSectorsViewDto(string warehouseName, string warehouseLocation, int numberOfWarehouseWorkers, int numberOfVanDrivers, decimal warehouseArea, int numberOfSectors, string warehouseImage, List<SectorDto> sectorDtos)
        {
            WarehouseName = warehouseName;
            WarehouseLocation = warehouseLocation;
            NumberOfWarehouseWorkers = numberOfWarehouseWorkers;
            NumberOfVanDrivers = numberOfVanDrivers;
            WarehouseArea = warehouseArea;
            NumberOfSectors = numberOfSectors;
            WarehouseImage = warehouseImage;
            SectorDtos = sectorDtos;
        }

        public WarehouseAndSectorsViewDto(Warehouse warehouse, List<SectorDto> sectorDtos)
        {
            WarehouseName = warehouse.WarehouseName;
            WarehouseLocation = warehouse.WarehouseLocation;
            NumberOfWarehouseWorkers = warehouse.NumberOfWarehouseWorkers;
            NumberOfVanDrivers = warehouse.NumberOfVanDrivers;
            WarehouseArea = warehouse.WarehouseArea;
            NumberOfSectors = warehouse.NumberOfSectors;
            WarehouseImage = warehouse.WarehouseImage;
            SectorDtos = sectorDtos;
        }
    }
}
