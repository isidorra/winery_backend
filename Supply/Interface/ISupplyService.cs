namespace winery_backend.Invetory.Interface
{
    public interface ISupplyService
    {
        ICollection<Supply.Supply> GetAll();
        Supply.Supply GetById(int id);
    }
}
