namespace winery_backend.PackingRequest.Interface
{
    public interface IPackingRequestRepository
    {
        bool IsExistPackingRequestBySectorIdAndCustomerOrderId(int sectorId, int customerOrderId);
        int FindLastId();
        bool SavePackingRequest(PackingRequest.Models.PackingRequest packingRequest);
    }
}
