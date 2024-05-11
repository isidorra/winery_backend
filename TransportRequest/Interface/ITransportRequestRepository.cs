namespace winery_backend.TransportRequest.Interface
{
    public interface ITransportRequestRepository
    {
        bool SaveTransportRequest(TransportRequest.Models.TransportRequest transportRequest);
        int FindLastId();
    }
}
