using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

public class AuthService : IAuthService
{
    private readonly ICustomerRepository _customerRepository;
    public AuthService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public string HashPassword(string? password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }


}