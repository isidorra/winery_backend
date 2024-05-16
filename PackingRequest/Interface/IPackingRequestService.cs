using winery_backend.ViewWarehouse.Models;
using winery_backend.WarehousemanPackingRequest.Dto;

namespace winery_backend.PackingRequest.Interface
{
    public interface IPackingRequestService
    {
        List<int> FindAllUnassignedSectors(List<int> sectorIds, int customerOrderId);
        bool CreatePackingRequest(int sectorId, DateTime packingDeadlineDate, List<int> products, List<int> quantities, int customerOrderId);
        List<DateTime> FindPackingRequestDeadlineDateByCustomerOrderId(int customerOrderId);
        List<WarehousemanPackingRequestsViewDto> FindWarehousemanActivePackingRequests(List<int> unpackedPackingRequestIds);
        PackingRequest.Models.PackingRequest FindPackingRequestById(int id);
        void UpdatePacked(PackingRequest.Models.PackingRequest packingRequest);
        int FindCustomerOrderIdById(int id);
        List<int> FindUnpackedIdsBySectorId(int sectorId);
        bool IsAllPacked(int customerOrderId);
    }
}
