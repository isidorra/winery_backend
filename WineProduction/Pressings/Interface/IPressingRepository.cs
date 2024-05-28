using winery_backend.WineProduction.Fermentations;

namespace winery_backend.WineProduction.Pressings.Interface
{
    public interface IPressingRepository
    {
        ICollection<Pressing> GetAll();
        Pressing GetById(int id);
        bool Create(Pressing pressing);
        bool Save();
        void Update(Pressing pressing);
    }
}
