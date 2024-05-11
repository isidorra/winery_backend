namespace winery_backend.TransportRequest.Interface
{
    public interface ITransportRequestService
    {
        bool CreateTransportRequest(TransportRequest.Models.TransportRequest transportRequest);
        int FindLastId();
    }
}
