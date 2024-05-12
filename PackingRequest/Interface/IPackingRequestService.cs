namespace winery_backend.PackingRequest.Interface
{
    public interface IPackingRequestService
    {
        List<int> FindAllUnassignedSectors(List<int> sectorIds, int customerOrderId);
        bool CreatePackingRequest(int sectorId, DateTime packingDeadlineDate, List<int> products, List<int> quantities, int customerOrderId);
        List<DateTime> FindPackingRequestDeadlineDateByCustomerOrderId(int customerOrderId);
    }
}
