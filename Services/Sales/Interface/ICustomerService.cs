using Microsoft.AspNetCore.Mvc;

public interface ICustomerService {
    ICollection<Customer> GetAll();
    Customer GetById(int id);
    Customer GetByUsername(string username);
    bool Exists(int id);
    bool Save();
    bool Create(Customer customer);

    bool AreFieldsFilled(Customer customer);

    bool UsernameExist(string username);

    bool SufficientUsernameLenght(string username);

    bool SufficientFirstnameLenght(string firstname);

    bool SufficientLastnameLenght(string lastname);

    bool IsValidEmail(string email);

    bool IsValidPhoneNumber(string phoneNumber);

    bool PhoneNumberExist(string phoneNumber);

    bool IsDigitsOnly(string phoneNumber);

    bool IsValidAge(DateTime? birthDate);

    Customer Authenticate(string? username, string? password);
    void Update(EditCustomerDto editedCustomer, int customerId);
}