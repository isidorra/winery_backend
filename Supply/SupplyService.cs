using winery_backend.Invetory.Interface;
using winery_backend.Supply;

namespace winery_backend.Invetory
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;

        public SupplyService(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public ICollection<Supply.Supply> GetAll()
        {
            throw new NotImplementedException();
        }

        public Supply.Supply GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
