namespace winery_backend.Machines.Interface
{
    public interface IMachineRepository
    {
        ICollection<Machine> GetAll();
        Machine GetById(int id);
        Machine GetByName(string name);
    }
}
