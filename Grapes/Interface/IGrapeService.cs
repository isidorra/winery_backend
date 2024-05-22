using Supplies;

namespace winery_backend.Grapes.Interface
{
    public interface IGrapeService
    {
        ICollection<Grape> GetAll();
        Grape GetById(int id);
        double GetHarvestedAmount (int id);
        void AddHarvestedGrape(int id, double amount);
    }
}
