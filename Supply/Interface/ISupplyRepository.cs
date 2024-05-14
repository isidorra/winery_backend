namespace winery_backend.Invetory.Interface
{
    public interface ISupplyRepository
    {
        ICollection<Supply.Supply> GetAll();
        Supply.Supply GetById(int id);
        Supply.Supply GetByName(string name);

        bool Create(Supply.Supply supply);

        bool Save();

        void Update(Supply.Supply supply);
    }
}
