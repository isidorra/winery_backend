using winery_backend.Grapes;
using winery_backend.Grapes.Interface;
using winery_backend.Machines;
using winery_backend.Machines.Interface;
using winery_backend.WineProduction.Fermentations.Dto;
using winery_backend.WineProduction.Pressings.Dto;
using winery_backend.WineProduction.Pressings.Interface;

namespace winery_backend.WineProduction.Pressings
{
    public class PressingService : IPressingService
    {

        private readonly IPressingRepository _pressingRepository;
        private readonly IGrapeService _grapeService;
        private readonly IMachineService _machineService;

        public PressingService(IPressingRepository pressingRepository, IGrapeService grapeService, IMachineService machineService)
        {
            _pressingRepository = pressingRepository;
            _grapeService = grapeService;
            _machineService = machineService;
        }

        public bool Create(PressingDto pressingDto)
        {
            Grape grape = _grapeService.GetByName(pressingDto.grapeName);

            //da li imamo slobodne kontejnere/bacve
            ICollection<Machine> machines= _machineService.GetByName("Pressing");
            if (machines == null || machines.Count == 0)
            {
                return false;
            }

            //da li imamo toliko grozdja
            if (_grapeService.GetById(grape.Id).FermentedAmount < pressingDto.amount)
            {
                return false;
            }

            PressingType.TryParse(pressingDto.PressingType, out PressingType type);

            Pressing pressing = new Pressing(grape.Id, pressingDto.amount, pressingDto.startDate, pressingDto.endDate, type);
            return _pressingRepository.Create(pressing);
        }

        public ICollection<Pressing> GetAll()
        {
            return _pressingRepository.GetAll();
        }

        public Pressing GetById(int id)
        {
            return _pressingRepository.GetById(id);
        }

        public bool Save()
        {
            return _pressingRepository.Save();
        }

        public void Update(Pressing pressing)
        {
            _pressingRepository.Update(pressing);
        }
    }
}
