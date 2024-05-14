using winery_backend.PackingRequest.Repository;
using winery_backend.WarehousemanPackingRequest.Dto;

namespace winery_backend.PackingRequest.Interface
{
    public interface IPackingRequestRepository
    {
        bool IsExistPackingRequestBySectorIdAndCustomerOrderId(int sectorId, int customerOrderId);
        int FindLastId();
        bool SavePackingRequest(PackingRequest.Models.PackingRequest packingRequest);
        List<PackingRequest.Models.PackingRequest> FindPackingRequestByCustomerOrderId(int customerOrderId);
        List<WarehousemanPackingRequestsViewDto> FindWarehousemanActivePackingRequests(List<int> unpackedPackingRequestIds);
        PackingRequest.Models.PackingRequest FindPackingRequestById(int id);
        void UpdatePacked(PackingRequest.Models.PackingRequest packingRequest);
        int FindCustomerOrderIdById(int id);
        List<int> FindUnpackedIdsBySectorId(int sectorId);
        List<PackingRequest.Models.PackingRequest> FindAllPackingRequestByIdAndSectorId(int customerOrderId);
        bool IsAllPacked(int customerOrderId);
    }
}
