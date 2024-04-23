namespace winery_backend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Employee> GetAll()
        {
            return _context.Employees.OrderBy(c => c.Id).ToList();
        }

        public Employee GetByUsername(string username)
        {
            return _context.Employees.Where(c => c.Username.Equals(username)).FirstOrDefault();
        }
        public Employee GetById(int id)
        {
            return _context.Employees.Where(c => c.Id == id).FirstOrDefault();
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

        public bool PhoneNumberExist(string phoneNumber)
        {
            return _context.Employees.Any(c => c.PhoneNumber.Equals(phoneNumber));
        }

        public void Update(Employee employee)
        {
            var editedEmployee = _context.Employees.FirstOrDefault(c => c.Id == employee.Id);
            if (editedEmployee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            try
            {
                _context.Update(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit employee", ex);
            }

        }
    }
}
