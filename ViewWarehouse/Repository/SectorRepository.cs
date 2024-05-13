using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.ViewWarehouse.Interface;
using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Repository
{
    public class SectorRepository : ISectorRepository
    {
        private readonly DataContext _context;
        public SectorRepository(DataContext context)
        {
            _context = context;
        }

        public string FindSectorName(int sectorId)
        {
            return _context.Sectors.First(x => x.SectorId == sectorId).SectorName;
        }

        public int FindSectorId(string sectorName)
        {
            return _context.Sectors.First(x => x.SectorName.Equals(sectorName)).SectorId;
        }

        public string FindSectorNameByWarehousemanId(int warehousemanId)
        {
            return _context.Sectors.First(x => x.WarehousemanId == warehousemanId).SectorName;
        }

        public List<Sector> FindAllSectors(int warehouseId)
        {
            return _context.Sectors.Where(x => x.WarehouseId == warehouseId).ToList();
        }

        public Sector FindSectorBySectorName(string sectorName)
        {
            return _context.Sectors.First(x => x.SectorName.Equals(sectorName));
        }
    }
}
