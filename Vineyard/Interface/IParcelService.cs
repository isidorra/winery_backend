namespace winery_backend.Vineyard.Interface
{
    public interface IParcelService
    {        
        ICollection<Parcel> GetAll();
        ICollection<Parcel> GetByGrape(string grape);
        Parcel GetById(int id);
        long RecommendWateringAmount(int parcelId);
    }
}
