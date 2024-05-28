using winery_backend.Activity;
using winery_backend.WineProduction.Fermentations.Dto;

namespace winery_backend.WineProduction.Fermentations.Interface
{
    public interface IFermentationService
    {
        ICollection<Fermentation> GetAll();
        Fermentation GetById(int id);
        bool Create(FermentationDto fermentationDto);
        bool Save();
        void Update(Fermentation fermentation);

        void UpdateFinishedFertilizations();
    }
}
