using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Interface;
using winery_backend.PackingRequest.Models;
using winery_backend.ViewWarehouse.Models;
using winery_backend.WarehousemanPackingRequest.Dto;

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
            PackingRequest.Models.PackingRequest packingRequest = new Models.PackingRequest(_packingRequestRepository.FindLastId(), packingDeadlineDate, DateTime.Now, products, quantities, customerOrderId, sectorId, false);

            return _packingRequestRepository.SavePackingRequest(packingRequest);
        }

        public List<DateTime> FindPackingRequestDeadlineDateByCustomerOrderId(int customerOrderId)
        {
            List<PackingRequest.Models.PackingRequest> packingRequests =  _packingRequestRepository.FindPackingRequestByCustomerOrderId(customerOrderId);

            List<DateTime> dateTimes = new List<DateTime>();

            foreach(var packingRequest in packingRequests)
            {
                dateTimes.Add(packingRequest.PackingRequestDeadlineDate);
            }

            return dateTimes;
        }

        public List<int> FindUnpackedIdsBySectorId(int sectorId)
        {
            return _packingRequestRepository.FindUnpackedIdsBySectorId(sectorId);
        }

        public List<WarehousemanPackingRequestsViewDto> FindWarehousemanActivePackingRequests(List<int> unpackedPackingRequestIds)
        {
            return _packingRequestRepository.FindWarehousemanActivePackingRequests(unpackedPackingRequestIds);
        }

        public PackingRequest.Models.PackingRequest FindPackingRequestById(int id)
        {
            return _packingRequestRepository.FindPackingRequestById(id);
        }

        public void UpdatePacked(PackingRequest.Models.PackingRequest packingRequest)
        {
            _packingRequestRepository.UpdatePacked(packingRequest);
        }

        public int FindCustomerOrderIdById(int id)
        {
            return _packingRequestRepository.FindCustomerOrderIdById(id);
        }

        public bool IsAllPacked(int customerOrderId)
        {
            return _packingRequestRepository.IsAllPacked(customerOrderId);
        }
    }
}
