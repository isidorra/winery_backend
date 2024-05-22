using Supplies;

namespace winery_backend.Activity.Interface
{
    public interface IActivityRepository
    {
        ICollection<Activity> GetAll();
        ICollection<Harvesting> GetAllHarvestings();
        ICollection<Activity> GetByParcelId(int parcelId);
        Activity GetById(int id);
        bool Create(Activity activity);
        bool Save();
        void Update(Activity activity);

    }
}
