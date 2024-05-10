using winery_backend.PackingRequest.Interface;

namespace winery_backend.PackingRequest.Service
{
    public class PackingRequestService : IPackingRequestService
    {
        private readonly IPackingRequestRepository _packingRequestRepository;
        public PackingRequestService(IPackingRequestRepository packingRequestRepository)
        {
            _packingRequestRepository = packingRequestRepository;
        }

        /*public List<Product> FindProductsByCustomerOrderId(List<int> productIds)
        {
            return _packingRequestRepository.FindProductsByCustomerOrderId(productIds);
        }*/
    }
}
