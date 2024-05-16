namespace winery_backend.TransportRequest.Interface
{
    public interface ITransportRequestService
    {
        bool CreateTransportRequest(TransportRequest.Models.TransportRequest transportRequest);
        int FindLastId();
        void Update(int customerOrderId, int vanDriverId, DateTime pickUpPackagesDeadlineDate);
        void Delete(int customerOrderId);
        List<TransportRequest.Models.TransportRequest> FindByVanDriverId(int vanDriverId);
        TransportRequest.Models.TransportRequest FindById(int transportRequestId);
    }
}
