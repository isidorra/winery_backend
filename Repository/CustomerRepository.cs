
public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Customer> GetAll()
    {
        return _context.Customers.OrderBy(c => c.Id).ToList();
    }

    public Customer GetById(int id)
    {
        return _context.Customers.Where(c => c.Id == id).FirstOrDefault();
    }

    public Customer GetByUsername(string username)
    {
        return _context.Customers.Where(c => c.Username == username).FirstOrDefault();
    }

    public bool Exists(int id)
    {
        return _context.Customers.Any(c => c.Id == id);
    }
    public bool Create(Customer customer)
    {
        _context.Add(customer);
        return Save();
    }
    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }




}