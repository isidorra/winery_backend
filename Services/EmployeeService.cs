using winery_backend.Repository;

namespace winery_backend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Authenticate(string? username, string? password)
        {
            Employee employee = _employeeRepository.GetByUsername(username);

            if (employee == null || !VerifyPasswordHash(password, employee.Password))
            {
                return null;
            }

            // Authentication successful, return the user
            return employee;
        }

        private bool VerifyPasswordHash(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public Employee GetByUsername(string username)
        {
            return _employeeRepository.GetByUsername(username);
        }

        public bool CreateEmployee(Employee employee)
        {
            return _employeeRepository.Create(employee);
        }

        public bool UsernameExist(string username)
        {
            return _employeeRepository.UsernameExist(username);
        }
    }
}
