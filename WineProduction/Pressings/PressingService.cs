using winery_backend.WineProduction.Pressings.Dto;
using winery_backend.WineProduction.Pressings.Interface;

namespace winery_backend.WineProduction.Pressings
{
    public class PressingService : IPressingService
    {

        private readonly IPressingRepository _pressingRepository;

        public PressingService(IPressingRepository pressingRepository)
        {
            _pressingRepository = pressingRepository;
        }

        public bool Create(PressingDto pressingDto)
        {
            throw new NotImplementedException();
        }

        public ICollection<Pressing> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pressing GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Pressing pressing)
        {
            throw new NotImplementedException();
        }
    }
}
