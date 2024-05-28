using Mysqlx.Crud;
using winery_backend.Grapes.Interface;

namespace winery_backend.Grapes
{
    public class GrapeService : IGrapeService
    {

        private readonly IGrapeRepository _grapeRepository;
        public GrapeService(IGrapeRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;
        }

        public ICollection<Grape> GetAll()
        {
            return _grapeRepository.GetAll();
        }

        public Grape GetById(int id)
        {
            return _grapeRepository.GetById(id);
        }

        public Grape GetByName(string name)
        {
            return _grapeRepository.GetByName(name);
        }

        public double GetHarvestedAmount(int id)
        {
            return _grapeRepository.GetById(id).HarvestedAmount;
        }

        public void AddHarvestedGrape(int id, double amount)
        {
            Grape grape = GetById(id);
            grape.HarvestedAmount += amount;
            _grapeRepository.Update(grape);
        }

        public void Update(Grape grape)
        {
            _grapeRepository.Update(grape);
        }
    }
}
