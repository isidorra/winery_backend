namespace winery_backend.Invetory.Interface
{
    public interface ISupplyService
    {
        ICollection<Supply> GetAll();
        Supply GetById(int id);
    }
}
