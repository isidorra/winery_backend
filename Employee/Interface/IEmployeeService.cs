using winery_backend.Repository;

namespace winery_backend.Services
{
    public interface IEmployeeService
    {
        ICollection<Employee> GetAll();
        Employee Authenticate(string? username, string? password);
        Employee GetByUsername(string username);
        bool CreateEmployee(Employee employee);
        bool AreFieldsFilled(Employee employee);
        bool UsernameExist(string username);
        void Update(EditEmployeeDto editEmployeeDto, int emoloyeeId);
        List<string> FindAllVanDriverNames();
        int FindVanDriverId(string username);
    }
}
