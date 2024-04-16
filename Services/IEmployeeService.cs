using winery_backend.Repository;

namespace winery_backend.Services
{
    public interface IEmployeeService
    {
        Employee Authenticate(string? username, string? password);

        Employee GetByUsername(string username);

        bool CreateEmployee(Employee employee);

        bool UsernameExist(string username);
    }
}
