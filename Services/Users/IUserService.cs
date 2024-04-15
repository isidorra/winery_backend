
public interface IUserService
{
    User Authenticate(string? username, string? password);

    User GetByUsername(string username);

    bool CreateEmployee(Employee employee);
}
