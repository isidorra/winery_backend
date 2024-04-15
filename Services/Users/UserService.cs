
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Authenticate(string? username, string? password)
    {
        var user = _userRepository.GetByUsername(username);

        if (user == null || !VerifyPasswordHash(password, user.Password))
        {
            return null;
        }

        // Authentication successful, return the user
        return user;
    }

    private bool VerifyPasswordHash(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public User GetByUsername(string username)
    {
        return _userRepository.GetByUsername(username);
    }

    public bool CreateEmployee(Employee employee)
    {
        return _userRepository.CreateEmployee(employee);
    }

}
