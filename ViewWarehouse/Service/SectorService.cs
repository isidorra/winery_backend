using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Interface;
using winery_backend.ViewWarehouse.Interface;
using winery_backend.ViewWarehouse.Models;

namespace winery_backend.ViewWarehouse.Service
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public List<string> FindSectorsName(List<int> requiredSectorIds)
        {
            List<string> sectorNames = new List<string>();
            foreach(int sectorId in requiredSectorIds)
            {
                sectorNames.Add(_sectorRepository.FindSectorName(sectorId));
            }

            return sectorNames;
        }

        public int FindSectorId(string sectorName)
        {
            return _sectorRepository.FindSectorId(sectorName);
        }

        public string FindSectorName(int sectorId)
        {
            return _sectorRepository.FindSectorName(sectorId);
        }

        public List<int> FindSectorIds(List<string> sectorNames)
        {
            List<int> sectorIds = new List<int>();
            foreach (string sectorName in sectorNames)
            {
                sectorIds.Add(_sectorRepository.FindSectorId(sectorName));
            }

            return sectorIds;
        }

        public string FindSectorNameByWarehousemanId(int warehousemanId)
        {
            return _sectorRepository.FindSectorNameByWarehousemanId(warehousemanId);
        }

        public List<Sector> FindAllSectors(int warehouseId)
        {
            return _sectorRepository.FindAllSectors(warehouseId);
        }

        public Sector FindSectorBySectorName(string sectorName)
        {
            return _sectorRepository.FindSectorBySectorName(sectorName);
        }

        public int FindSectorIdByWarehousemanId(int warehousemanId)
        {
            return _sectorRepository.FindSectorIdByWarehousemanId(warehousemanId);
        }
    }
}
