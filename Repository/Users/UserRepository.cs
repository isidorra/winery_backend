using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{

    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public User GetByUsername(string username)
    {
        return _context.Customers.Where(c => c.Username == username).FirstOrDefault();
    }

    public bool CreateEmployee(Employee employee)
    {
        _context.Add(employee);
        return SaveEmployee();
    }

    public bool SaveEmployee()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}

