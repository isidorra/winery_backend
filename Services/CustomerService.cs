
using Microsoft.AspNetCore.Mvc;

public class CustomerService : ICustomerService {
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository) {
        _customerRepository = customerRepository;
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
        return _customerRepository.Create(customer);
    }
}