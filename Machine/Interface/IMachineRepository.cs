namespace winery_backend.Machine.Interface
{
    public interface IMachineRepository
    {
        ICollection<Machine> GetAll();
        Machine GetById(int id);
    }
}
