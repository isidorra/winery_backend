using Supplies;

namespace winery_backend.Supplies.Interface
{
    public interface ISupplyRepository
    {
        ICollection<Supply> GetAll();
        Supply GetById(int id);
        Supply GetByName(string name);

        bool Create(Supply supply);

        bool Save();

        void Update(Supply supply);
    }
}
