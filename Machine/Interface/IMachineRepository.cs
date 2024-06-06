namespace winery_backend.Machines.Interface
{
    public interface IMachineRepository
    {
        ICollection<Machine> GetAll();
        Machine GetById(int id);
        ICollection<Machine> GetByName(string name);
    }
}
