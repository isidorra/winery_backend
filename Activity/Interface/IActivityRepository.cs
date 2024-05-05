namespace winery_backend.Activity.Interface
{
    public interface IActivityRepository
    {
        ICollection<Activity> GetAll();
        ICollection<Activity> GetByParcelId(int parcelId);
        Activity GetById(int id);
    }
}
