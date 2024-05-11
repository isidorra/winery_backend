using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Interface;
using winery_backend.ViewWarehouse.Interface;

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
    }
}
