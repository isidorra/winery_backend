
using Supplies;

namespace winery_backend.Supplies.Interface
{
    public interface ISupplyService
    {
        ICollection<Supply> GetAll();
        Supply GetById(int id);
        ICollection<Supply> GetBySupplyType(SupplyType type);

    }
}
