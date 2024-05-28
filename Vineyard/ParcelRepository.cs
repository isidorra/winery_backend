using winery_backend.Grapes;
using winery_backend.Vineyard.Interface;

namespace winery_backend.Vineyard
{
    public class ParcelRepository : IParcelRepository
    {
        private readonly DataContext _context;

        public ParcelRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Parcel> GetAll()
        {
            return _context.Parcels.OrderBy(p => p.Id).ToList();
        }


        public Parcel GetById(int id)
        {
            return _context.Parcels.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
