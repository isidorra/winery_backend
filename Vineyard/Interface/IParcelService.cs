namespace winery_backend.Vineyard.Interface
{
    public interface IParcelService
    {        
        ICollection<Parcel> GetAll();
        Parcel GetById(int id);
        long RecommendWateringAmount(int parcelId);
    }
}
