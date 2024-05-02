using Microsoft.AspNetCore.Mvc;

public interface ICustomerService {
    ICollection<Customer> GetAll();
    Customer GetById(int id);
    Customer GetByUsername(string username);
    bool Exists(int id);
    bool Save();
    bool Create(Customer customer);
    bool UsernameExist(string username);
    Customer Authenticate(string? username, string? password);
    void Update(EditCustomerDto editedCustomer, int customerId);
}