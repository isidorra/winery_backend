using System.Collections.ObjectModel;
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

        public ICollection<Parcel> GetByGrape(string grape)
        {
            ICollection<Parcel> allParcels = _parcelRepository.GetAll();
            ICollection<Parcel> fillteredParcels = new Collection<Parcel>();

            foreach (Parcel parcel in allParcels)
            {
                if (parcel.Grape.Name.Equals(grape))
                {
                    fillteredParcels.Add(parcel);
                }
            }

            return fillteredParcels;

        }

        public Parcel GetById(int id)
        {
            return _parcelRepository.GetById(id);
        }

        public double RecommendWateringAmount(int parcelId)
        {
            Parcel parcel = GetById(parcelId);
            return parcel.RecommendedWateringAmount();
        }

    }

}
