
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
        
        if (UsernameExist(customer.Username))
            return false;
        return _customerRepository.Create(customer);
    }

    

    public bool UsernameExist(string username)
    {
        return _customerRepository.UsernameExist(username) || _employeeService.UsernameExist(username);
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
                customer.Floor = editCustomerDto.Floor;
            }
            if (!string.IsNullOrEmpty(editCustomerDto.Door))
            {
                customer.Door = editCustomerDto.Door;
            }
            if (editCustomerDto.City != null)
            {
                customer.CityId = editCustomerDto.City;
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

