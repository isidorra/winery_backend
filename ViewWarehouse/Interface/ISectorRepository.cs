using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Interface
{
    public interface ISectorRepository
    {
        string FindSectorName(int sectorId);
        int FindSectorId(string sectorName);
        string FindSectorNameByWarehousemanId(int warehousemanId);
        List<Sector> FindAllSectors(int warehouseId);
        Sector FindSectorBySectorName(string sectorName);
    }
}
