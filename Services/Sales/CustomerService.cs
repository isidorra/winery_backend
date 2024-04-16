
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using winery_backend.Services;

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
        // ogranicenje za duzinu, najmanje
        if (UsernameExist(customer.Username))
        {
            System.Diagnostics.Debug.WriteLine("eeeeeee");
            return false;
        }
        else if(!customer.Firstname.All(char.IsLetter))
        {
            System.Diagnostics.Debug.WriteLine("ddddddd");
            return false;
        }
        else if (!customer.Lastname.All(char.IsLetter))
        {
            System.Diagnostics.Debug.WriteLine("ccccccc");
            return false;
        }
        else if (!IsValidEmail(customer.Email))
        {
            System.Diagnostics.Debug.WriteLine("bbbbbb");
            return false;
        }
        // za lozinku treba videti ono sa ponavljanjem da li samo na frontend-u
        // za broj telefona treba videti kako to da se ogranici
        else if (!IsValidAge(customer.BirthDate)) // NIJE URADJENO
        {
            return false;
        }
        // za pol ce biti radio buttons, pa ce moci samo to da izabere, nema potrebe za proverom
        return _customerRepository.Create(customer);
    }

    public bool AreFieldsFilled(Customer customer)
    {
        /*if(customer.Username.Equals("") || customer.Firstname.Equals("") || customer.Lastname.Equals("") || customer.Email.Equals("") || customer.Password.Equals("") || customer.Gender
        {
            return false;
        }*/
        return false;
    }

    public bool UsernameExist(string username)
    {
        return _customerRepository.UsernameExist(username) || _employeeService.UsernameExist(username);
    }

    public bool IsValidEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }

    public bool IsValidAge(DateTime? birthDate)
    {
        return true;
        // return birthDate.AddYears(18) <= DateTime.Now;
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

}