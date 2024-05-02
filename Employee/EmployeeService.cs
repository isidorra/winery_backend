using System.Text.RegularExpressions;

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
            else if (!SufficientUsernameLenght(employee.Username))
            {
                return false;
            }
            else if (!SufficientFirstnameLenght(employee.Firstname))
            {
                return false;
            }
            else if (!employee.Firstname.All(char.IsLetter))
            {
                return false;
            }
            else if (!SufficientLastnameLenght(employee.Lastname))
            {
                return false;
            }
            else if (!employee.Lastname.All(char.IsLetter))
            {
                return false;
            }
            else if (!IsValidEmail(employee.Email))
            {
                return false;
            }
            else if (!IsValidPhoneNumber(employee.PhoneNumber))
            {
                return false;
            }
            else if (!IsValidAge(employee.BirthDate))
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

        public bool SufficientUsernameLenght(string username)
        {
            if (username.Length <= 4)
            {
                return false;
            }

            return true;
        }

        public bool SufficientFirstnameLenght(string firstname)
        {
            if (firstname.Length <= 1)
            {
                return false;
            }

            return true;
        }

        public bool SufficientLastnameLenght(string lastname)
        {
            if (lastname.Length <= 2)
            {
                return false;
            }

            return true;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            if (!(_customerRepository.PhoneNumberExist(phoneNumber) || PhoneNumberExist(phoneNumber)))
            {
                if (phoneNumber.Length == 9 || phoneNumber.Length == 10)
                {
                    if (IsDigitsOnly(phoneNumber))
                    {
                        if (phoneNumber.StartsWith("060") || phoneNumber.StartsWith("061") || phoneNumber.StartsWith("062") || phoneNumber.StartsWith("063") || phoneNumber.StartsWith("064") || phoneNumber.StartsWith("065") || phoneNumber.StartsWith("066") || phoneNumber.StartsWith("067") || phoneNumber.StartsWith("068") || phoneNumber.StartsWith("069"))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            return false;
        }

        public bool IsDigitsOnly(string phoneNumber)
        {
            foreach (char c in phoneNumber)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public bool IsValidAge(DateTime? birthDate)
        {
            DateTime date = birthDate.Value;

            return date.AddYears(18) <= DateTime.Now;
        }

        public bool UsernameExist(string username)
        {
            return _employeeRepository.UsernameExist(username);
        }

        public bool PhoneNumberExist(string username)
        {
            return _employeeRepository.PhoneNumberExist(username);
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
                if (!string.IsNullOrEmpty(editEmployeeDto.Username))
                {
                    employee.Username = editEmployeeDto.Username;
                }
                if (!string.IsNullOrEmpty(editEmployeeDto.Password))
                {
                    employee.Password = editEmployeeDto.Password;
                }
                if (!string.IsNullOrEmpty(editEmployeeDto.ProfilePhoto))
                {
                    employee.PhoneNumber = editEmployeeDto.ProfilePhoto;
                }

                _employeeRepository.Update(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit employee", ex);
            }

        }

    }