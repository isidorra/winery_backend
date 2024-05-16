using Supplies;
using winery_backend.Invetory.Interface;

namespace winery_backend.Invetory
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;

        public SupplyService(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public ICollection<Supply> GetAll()
        {
           return _supplyRepository.GetAll();
        }

        public Supply GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
