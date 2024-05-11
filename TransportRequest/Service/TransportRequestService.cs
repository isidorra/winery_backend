using winery_backend.TransportRequest.Interface;
using winery_backend.TransportRequest.Models;

namespace winery_backend.TransportRequest.Service
{
    public class TransportRequestService : ITransportRequestService
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        public TransportRequestService(ITransportRequestRepository transportRequestRepository)
        {
            _transportRequestRepository = transportRequestRepository;
        }

        public bool CreateTransportRequest(TransportRequest.Models.TransportRequest transportRequest)
        {
            return _transportRequestRepository.SaveTransportRequest(transportRequest);
        }

        public int FindLastId()
        {
            return _transportRequestRepository.FindLastId();
        }
    }
}
