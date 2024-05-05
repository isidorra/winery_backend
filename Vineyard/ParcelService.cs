using winery_backend.Vineyard.Interface;

namespace winery_backend.Vineyard
{
    public class ParcelService : IParcelService
    {
        private readonly IParcelRepository _parcelRepository;

        public ParcelService(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public ICollection<Parcel> GetAll()
        {
            return _parcelRepository.GetAll();
        }

        public Parcel GetById(int id)
        {
            return _parcelRepository.GetById(id);
        }

        public long RecommendWateringAmount(int parcelId)
        {
            Parcel parcel = GetById(parcelId);
            return parcel.RecommendedWateringAmount();
        }
    }

}
