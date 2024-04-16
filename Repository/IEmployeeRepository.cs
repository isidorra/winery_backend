namespace winery_backend.Repository
{
    public interface IEmployeeRepository
    {
        Employee GetByUsername(string username);

        bool Create(Employee employee);

        bool Save();

        bool UsernameExist(string username);

        bool PhoneNumberExist(string phoneNumber);
    }
}
