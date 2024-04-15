
public interface IUserRepository
{
    User GetByUsername(string username);

    bool CreateEmployee(Employee employee);

    bool SaveEmployee();
}

