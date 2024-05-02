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
            switch(employee.Role)
            {
                case Role.ADMINISTRATOR:
                    _context.Administrators.Add(new Administrator(employee));
                    break;
                case Role.OWNER:
                    _context.Owners.Add(new Owner(employee));
                    break;
                case Role.DRIVER: 
                    _context.VanDrivers.Add(new VanDriver(employee));
                    break;
                case Role.LOGISTICIAN:
                    _context.Logisticians.Add(new Logistician(employee));
                    break;
                case Role.MARKETING_MANAGER:
                    _context.MarketingManagers.Add(new MarketingManager(employee));
                    break;
                case Role.WAREHOUSEMAN:
                    _context.Warehousemen.Add(new Warehouseman(employee));
                    break;
                case Role.SALES_MANAGER:
                    _context.SalesManagers.Add(new SalesManager(employee));
                    break;
                case Role.TECHNOLOGIST:
                    _context.Technologists.Add(new Technologist(employee));
                    break;
                case Role.TOUR_GUIDE:
                    _context.TourGuides.Add(new TourGuide(employee));
                    break;
                default:
                    Console.WriteLine("----------------");
                    break;

                
            }
            //_context.Employees.Add(employee);
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
