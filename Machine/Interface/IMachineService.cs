using Supplies;

namespace winery_backend.Machines.Interface
{
    public interface IMachineService
    {
        ICollection<Machine> GetAll();
        Machine GetById(int id);
        ICollection<Machine> GetByName (string name);
    }
}
