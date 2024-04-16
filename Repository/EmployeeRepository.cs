namespace winery_backend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public Employee GetByUsername(string username)
        {
            return _context.Employees.Where(c => c.Username.Equals(username)).FirstOrDefault();
        }

        public bool Create(Employee employee)
        {
            _context.Add(employee);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UsernameExist(string username)
        {
            return _context.Employees.Any(c => c.Username.Equals(username));
        }
    }
}
