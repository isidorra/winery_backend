using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Interface;
using winery_backend.PackingRequest.Models;

namespace winery_backend.PackingRequest.Service
{
    public class PackingRequestService : IPackingRequestService
    {
        private readonly IPackingRequestRepository _packingRequestRepository;
        public PackingRequestService(IPackingRequestRepository packingRequestRepository)
        {
            _packingRequestRepository = packingRequestRepository;
        }

        public List<int> FindAllUnassignedSectors(List<int> sectorIds, int customerOrderId)
        {
            List<int> unassignedSectors = new List<int>();

            foreach (int sectorId in sectorIds)
            {
                if(!_packingRequestRepository.IsExistPackingRequestBySectorIdAndCustomerOrderId(sectorId, customerOrderId))
                {
                    unassignedSectors.Add(sectorId);
                }
            }
            return unassignedSectors;
        }

        public bool CreatePackingRequest(int sectorId, DateTime packingDeadlineDate, List<int> products, List<int> quantities, int customerOrderId)
        {
            PackingRequest.Models.PackingRequest packingRequest = new Models.PackingRequest(_packingRequestRepository.FindLastId(), packingDeadlineDate, DateTime.Now, products, quantities, customerOrderId, sectorId);

            return _packingRequestRepository.SavePackingRequest(packingRequest);
        }
    }
}
