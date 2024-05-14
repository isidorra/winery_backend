using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Interface
{
    public interface ISectorService
    {
        List<string> FindSectorsName(List<int> requiredSectorIds);
        int FindSectorId(string sectorName);
        string FindSectorName(int sectorId);
        List<int> FindSectorIds(List<string> sectorNames);
        string FindSectorNameByWarehousemanId(int warehousemanId);
        List<Sector> FindAllSectors(int warehouseId);
        Sector FindSectorBySectorName(string sectorName);
        int FindSectorIdByWarehousemanId(int warehousemanId);
        Sector FindByWarehousemanId(int warehousemanId);
    }
}
