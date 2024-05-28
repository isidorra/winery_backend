namespace winery_backend.Grapes.Interface
{
    public interface IGrapeRepository
    {
        ICollection<Grape> GetAll();
        Grape GetById(int id);
        void Update(Grape grape);
        Grape GetByName(string name);

    }
}
