using Supplies;

namespace winery_backend.Machine.Interface
{
    public interface IMachineService
    {
        ICollection<Machine> GetAll();
        Machine GetById(int id);
    }
}
