using Supplies;

namespace winery_backend.Machines.Interface
{
    public interface IMachineService
    {
        ICollection<Machine> GetAll();
        Machine GetById(int id);
        Machine GetByName (string name);
    }
}
