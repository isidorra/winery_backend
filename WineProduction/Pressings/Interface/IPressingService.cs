using winery_backend.WineProduction.Pressings.Dto;

namespace winery_backend.WineProduction.Pressings.Interface
{
    public interface IPressingService
    {
        ICollection<Pressing> GetAll();
        Pressing GetById(int id);
        bool Create(PressingDto pressingDto);
        bool Save();
        void Update(Pressing pressing);
    }
}
