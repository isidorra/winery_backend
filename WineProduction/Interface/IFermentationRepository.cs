namespace winery_backend.WineProduction.Interface
{
    public interface IFermentationRepository
    {
        ICollection<Fermentation> GetAll();
        Fermentation GetById(int id);
        bool Create(Fermentation fermentation);
        bool Save();
        void Update(Fermentation fermentation);
    }
}
