
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmployeeService _employeeService;
    public CustomerService(ICustomerRepository customerRepository, IEmployeeService employeeService)
    {
        _customerRepository = customerRepository;
        _employeeService = employeeService;
    }

    public bool Exists(int id)
    {
        return _customerRepository.Exists(id);
    }

    public ICollection<Customer> GetAll()
    {
        return _customerRepository.GetAll();
    }

    public Customer GetById(int id)
    {
        return _customerRepository.GetById(id);
    }

    public Customer GetByUsername(string username)
    {
        return _customerRepository.GetByUsername(username);
    }

    public bool Save()
    {
        return _customerRepository.Save();
    }

    public bool Create(Customer customer)
    {
        if (!AreFieldsFilled(customer))
        {
            return false;
        }
        if (UsernameExist(customer.Username))
        {
            return false;
        }
        else if (!SufficientUsernameLenght(customer.Username))
        {
            return false;
        }
        else if (!SufficientFirstnameLenght(customer.Firstname))
        {
            return false;
        }
        else if (!customer.Firstname.All(char.IsLetter))
        {
            return false;
        }
        else if (!SufficientLastnameLenght(customer.Lastname))
        {
            return false;
        }
        else if (!customer.Lastname.All(char.IsLetter))
        {
            return false;
        }
        else if (!IsValidEmail(customer.Email))
        {
            return false;
        }
        else if (!IsValidPhoneNumber(customer.PhoneNumber))
        {
            return false;
        }
        else if (!IsValidAge(customer.BirthDate))
        {
            return false;
        }

        return _customerRepository.Create(customer);
    }

    public bool AreFieldsFilled(Customer customer)
    {
        if(string.IsNullOrWhiteSpace(customer.Username) || string.IsNullOrWhiteSpace(customer.Firstname) || string.IsNullOrWhiteSpace(customer.Lastname) || string.IsNullOrWhiteSpace(customer.Email) || string.IsNullOrWhiteSpace(customer.Password) || string.IsNullOrWhiteSpace(customer.PhoneNumber) || !customer.BirthDate.HasValue)
        {
            return false;
        }

        return true;
    }

    public bool UsernameExist(string username)
    {
        return _customerRepository.UsernameExist(username) || _employeeService.UsernameExist(username);
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
        if(!PhoneNumberExist(phoneNumber))
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

    public bool PhoneNumberExist(string phoneNumber)
    {
        return _customerRepository.PhoneNumberExist(phoneNumber) || _employeeService.PhoneNumberExist(phoneNumber);
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


    public Customer Authenticate(string? username, string? password)
    {
        Customer customer = _customerRepository.GetByUsername(username);

        if (customer == null || !VerifyPasswordHash(password, customer.Password))
        {
            return null;
        }

        // Authentication successful, return the user
        return customer;
    }

    private bool VerifyPasswordHash(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public void Update(EditCustomerDto editCustomerDto, int customerId)
    {
        try
        {
            Customer customer = _customerRepository.GetById(customerId);
            if (!string.IsNullOrEmpty(editCustomerDto.FirstName))
            {
                customer.Firstname = editCustomerDto.FirstName;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.LastName))
            {
                customer.Lastname = editCustomerDto.LastName;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Email))
            {
                customer.Email = editCustomerDto.Email;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Username))
            {
                customer.Username = editCustomerDto.Username;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Password))
            {
                customer.Password = editCustomerDto.Password;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Street))
            {
                customer.Street = editCustomerDto.Street;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Number))
            {
                customer.Number = editCustomerDto.Number;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Floor))
            {
                customer.Floor = int.Parse(editCustomerDto.Floor);
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Door))
            {
                customer.Door = int.Parse(editCustomerDto.Door);
            }
            if (!string.IsNullOrEmpty(editCustomerDto.City))
            {
                customer.CityId = int.Parse(editCustomerDto.City);
            }
            if (!string.IsNullOrEmpty(editCustomerDto.ZipCode))
            {
                customer.Zip = editCustomerDto.ZipCode;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.PhoneNumber))
            {
                customer.PhoneNumber = editCustomerDto.PhoneNumber;
            }

            _customerRepository.Update(customer);
        }
        catch (Exception ex)
        {
            throw new Exception("Error while trying to edit customer", ex);
        }

    }

}