using System.Diagnostics;
using winery_backend.LogisticianViewCustomerOrder.Models;
using winery_backend.PackingRequest.Interface;
using winery_backend.PackingRequest.Models;
using winery_backend.ViewWarehouse.Models;
using winery_backend.WarehousemanPackingRequest.Dto;

namespace winery_backend.PackingRequest.Repository
{
    public class PackingRequestRepository : IPackingRequestRepository
    {
        private readonly DataContext _context;
        public PackingRequestRepository(DataContext context)
        {
            _context = context;
        }

        public bool IsExistPackingRequestBySectorIdAndCustomerOrderId(int sectorId, int customerOrderId)
        {
            return _context.PackingRequests.Any(x => x.SectorId == sectorId && x.CustomerOrderId == customerOrderId);
        }

        public int FindLastId()
        {
            if (_context.PackingRequests.Count() == 0)
            {
                return 1;
            }
            return _context.PackingRequests.Max(x => x.PackingRequestId) + 1;
        }

        public bool SavePackingRequest(PackingRequest.Models.PackingRequest packingRequest)
        {
            if(_context.PackingRequests.Any(x => x.CustomerOrderId == packingRequest.CustomerOrderId && x.SectorId == packingRequest.SectorId))
            {
                return false;
            }
            _context.PackingRequests.Add(packingRequest);
            _context.SaveChanges();

            return true;
        }

        public List<PackingRequest.Models.PackingRequest> FindPackingRequestByCustomerOrderId(int customerOrderId)
        {
            return _context.PackingRequests.Where(x => x.CustomerOrderId == customerOrderId).ToList();
        }

        public List<int> FindUnpackedIdsBySectorId(int sectorId)
        {
            List<int> ids = new List<int>();

            foreach(PackingRequest.Models.PackingRequest packingRequest in _context.PackingRequests)
            {
                if(packingRequest.SectorId == sectorId && packingRequest.Packed.Equals(false))
                {
                    ids.Add(packingRequest.PackingRequestId);
                }
            }
            return ids;
        }

        public List<WarehousemanPackingRequestsViewDto> FindWarehousemanActivePackingRequests(List<int> unpackedPackingRequestIds)
        {
            List<PackingRequest.Models.PackingRequest> packingRequests = new List<PackingRequest.Models.PackingRequest>();

            foreach (int packingRequestId in unpackedPackingRequestIds)
            {
                PackingRequest.Models.PackingRequest packingRequest = _context.PackingRequests.FirstOrDefault(x => x.PackingRequestId == packingRequestId);
                if(packingRequest != null)
                {
                    packingRequests.Add(packingRequest);
                }
            }

            List<WarehousemanPackingRequestsViewDto> warehousemanPackingRequestsViewDtos = new List<WarehousemanPackingRequestsViewDto>();

            foreach(PackingRequest.Models.PackingRequest packingRequest in packingRequests)
            {

                warehousemanPackingRequestsViewDtos.Add(new WarehousemanPackingRequestsViewDto(packingRequest.PackingRequestId, packingRequest.PackingRequestDeadlineDate));
            }

            return warehousemanPackingRequestsViewDtos;
        }

        public PackingRequest.Models.PackingRequest FindPackingRequestById(int id)
        {
            return _context.PackingRequests.First(x => x.PackingRequestId == id);
        }

        public void UpdatePacked(PackingRequest.Models.PackingRequest packingRequest)
        {
            packingRequest.Packed = true;

            _context.PackingRequests.Update(packingRequest);
            _context.SaveChanges();
        }

        public int FindCustomerOrderIdById(int id)
        {
            return _context.PackingRequests.First(x => x.PackingRequestId == id).CustomerOrderId;
        }

        public List<PackingRequest.Models.PackingRequest> FindAllPackingRequestByIdAndSectorId(int customerOrderId)
        {
            return _context.PackingRequests.Where(x => x.CustomerOrderId == customerOrderId).ToList();
        }

        public bool IsAllPacked(int customerOrderId)
        {
            List<PackingRequest.Models.PackingRequest> packingRequests = FindAllPackingRequestByIdAndSectorId(customerOrderId);

            foreach(PackingRequest.Models.PackingRequest packingRequest in packingRequests)
            {
                if(packingRequest.Packed.Equals(false))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
