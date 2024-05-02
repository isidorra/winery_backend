using System.Text.RegularExpressions;
using winery_backend.Repository;

namespace winery_backend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICustomerRepository _customerRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ICustomerRepository customerRepository)
        {
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public Employee GetByUsername(string username)
        {
            return _employeeRepository.GetByUsername(username);
        }

        public bool CreateEmployee(Employee employee)
        {
            if (!AreFieldsFilled(employee))
            {
                return false;
            }
            if (_customerRepository.UsernameExist(employee.Username) || UsernameExist(employee.Username))
            {
                return false;
            }
           
            return _employeeRepository.Create(employee);
        }

        public bool AreFieldsFilled(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Username) || string.IsNullOrWhiteSpace(employee.Firstname) || string.IsNullOrWhiteSpace(employee.Lastname) || string.IsNullOrWhiteSpace(employee.Email) || string.IsNullOrWhiteSpace(employee.Password) || string.IsNullOrWhiteSpace(employee.PhoneNumber) || !employee.BirthDate.HasValue)
            {
                return false;
            }

            return true;
        }

    

        public bool UsernameExist(string username)
        {
            return _employeeRepository.UsernameExist(username);
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

        public void Update(EditEmployeeDto editEmployeeDto, int employeeId)
        {
            try
            {
                Employee employee = _employeeRepository.GetById(employeeId);
                if (!string.IsNullOrEmpty(editEmployeeDto.Firstname))
                {
                    employee.Firstname = editEmployeeDto.Firstname;
                }
                if (!string.IsNullOrEmpty(editEmployeeDto.Lastname))
                {
                    employee.Lastname = editEmployeeDto.Lastname;
                }
                if (!string.IsNullOrEmpty(editEmployeeDto.Email))
                {
                    employee.Email = editEmployeeDto.Email;
                }
                if (!string.IsNullOrEmpty(editEmployeeDto.Password))
                {
                    employee.Password = editEmployeeDto.Password;
                }
                if (!string.IsNullOrEmpty(editEmployeeDto.PhoneNumber))
                {
                    employee.PhoneNumber = editEmployeeDto.PhoneNumber;
                }

                _employeeRepository.Update(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit employee", ex);
            }

        }

        public ICollection<Employee> GetAll()
        {
            return _employeeRepository.GetAll();
        }
    }
}
