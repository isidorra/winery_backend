namespace winery_backend.TransportRequest.Interface
{
    public interface ITransportRequestRepository
    {
        bool SaveTransportRequest(TransportRequest.Models.TransportRequest transportRequest);
        int FindLastId();
        void Update(int customerOrderId, int vanDriverId, DateTime pickUpPackagesDeadlineDate);
        TransportRequest.Models.TransportRequest FindByCustomerOrderId(int customerOrderId);
        void Delete(int customerOrderId);
        List<TransportRequest.Models.TransportRequest> FindByVanDriverId(int vanDriverId);
        TransportRequest.Models.TransportRequest FindById(int transportRequestId);
    }
}
