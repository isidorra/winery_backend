using System.Reflection.Metadata.Ecma335;
using winery_backend.Machines.Interface;
using winery_backend.Machines;
using winery_backend.Grapes.Interface;
using winery_backend.Grapes;
using winery_backend.Supplies.Interface;
using Supplies;
using winery_backend.WineProduction.Fermentations.Interface;
using winery_backend.WineProduction.Fermentations.Dto;
using winery_backend.Activity;

namespace winery_backend.WineProduction.Fermentations
{
    public class FermentationService : IFermentationService
    {
        private readonly IFermentationRepository _fermentationRepository;
        private readonly IMachineService _machineService;
        private readonly IGrapeService _grapeService;
        private readonly ISupplyService _supplyService;
        public FermentationService(IFermentationRepository fermentationRepository, IMachineService machineService, IGrapeService grapeService, ISupplyService supplyService)
        {
            _fermentationRepository = fermentationRepository;
            _machineService = machineService;
            _grapeService = grapeService;
            _supplyService = supplyService;
        }

        public void UpdateFinishedFertilizations()
        {
            ICollection<Fermentation> allFermentations = _fermentationRepository.GetAll();
            foreach (Fermentation fermentation in allFermentations)
            {

                if (fermentation.EndDate <= DateTime.Now)
                {
                    Grape grape = _grapeService.GetById(fermentation.GrapeId);
                    grape.FermentedAmount = grape.FermentedAmount + fermentation.Amount;
                    _grapeService.Update(grape);

                }

            }

        }

            public bool Create(FermentationDto fermentationDto)
        {
            Grape grape = _grapeService.GetByName(fermentationDto.grapeId);

            //da li imamo slobodne kontejnere/bacve
            Machine machine = _machineService.GetByName("Fermentation container");
            if (machine == null || machine.Amount == 0)
            {
                return false;
            }

            //da li imamo toliko grozdja
            if (_grapeService.GetById(grape.Id).HarvestedAmount < fermentationDto.amount)
            {
                return false;
            }

            //da li imamo toliko supplies
            ICollection<Supply> necceserySugarSupplies = _supplyService.GetBySupplyType(SupplyType.Sugar);
            double sugarAmount = 0;
            foreach (Supply supply in necceserySugarSupplies)
            {
                sugarAmount += supply.Amount;
            }

            if (sugarAmount < fermentationDto.sugar)
            {
                return false;
            }

            ICollection<Supply> necceseryYeastSupplies = _supplyService.GetBySupplyType(SupplyType.Yeast);
            double yeastAmount = 0;
            foreach (Supply supply in necceseryYeastSupplies)
            {
                yeastAmount += supply.Amount;
            }

            if (yeastAmount < fermentationDto.yeast)
            {
                return false;
            }

            Fermentation fermentation = new Fermentation(grape.Id, fermentationDto.amount, fermentationDto.startDate, fermentationDto.endDate, fermentationDto.yeast, fermentationDto.sugar, fermentationDto.temperature, fermentationDto.ph);
            return _fermentationRepository.Create(fermentation);

        }

        public ICollection<Fermentation> GetAll()
        {
            return _fermentationRepository.GetAll();
        }

        public Fermentation GetById(int id)
        {
            return _fermentationRepository.GetById(id);
        }

        public bool Save()
        {
            return _fermentationRepository.Save();
        }

        public void Update(Fermentation fermentation)
        {
            _fermentationRepository.Update(fermentation);
        }
    }
}
