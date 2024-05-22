using winery_backend.Grapes;

namespace winery_backend.Vineyard.Interface
{
    public interface IParcelRepository
    {
        ICollection<Parcel> GetAll();
        Parcel GetById(int id);
        HarvestedGrape GetHarvestedGrape(int grapeId);
    }
}
