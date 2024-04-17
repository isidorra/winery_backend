using winery_backend.Repository;

namespace winery_backend.Services
{
    public interface IEmployeeService
    {
        Employee Authenticate(string? username, string? password);

        Employee GetByUsername(string username);

        bool CreateEmployee(Employee employee);

        bool AreFieldsFilled(Employee employee);

        bool SufficientUsernameLenght(string username);

        bool SufficientFirstnameLenght(string firstname);

        bool SufficientLastnameLenght(string lastname);

        bool IsValidEmail(string email);

        bool IsValidPhoneNumber(string phoneNumber);

        bool IsDigitsOnly(string phoneNumber);

        bool IsValidAge(DateTime? birthDate);

        bool UsernameExist(string username);

        bool PhoneNumberExist(string username);
        void Update(EditEmployeeDto editEmployeeDto, int emoloyeeId);
    }
}
