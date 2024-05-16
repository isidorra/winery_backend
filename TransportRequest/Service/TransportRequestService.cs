using winery_backend.LogisticianViewCustomerOrder.Models;
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

        public void Update(int customerOrderId, int vanDriverId, DateTime pickUpPackagesDeadlineDate)
        {
            _transportRequestRepository.Update(customerOrderId, vanDriverId, pickUpPackagesDeadlineDate);
        }

        public void Delete(int customerOrderId)
        {
            _transportRequestRepository.Delete(customerOrderId);
        }

        public List<TransportRequest.Models.TransportRequest> FindByVanDriverId(int vanDriverId)
        {
            return _transportRequestRepository.FindByVanDriverId(vanDriverId);
        }

        public TransportRequest.Models.TransportRequest FindById(int transportRequestId)
        {
            return _transportRequestRepository.FindById(transportRequestId);
        }
    }
}
