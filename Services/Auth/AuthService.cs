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

    public string GenerateJwtToken(Customer customer)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new Claim(ClaimTypes.Name, customer.Username),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789098765432123456uhbvsdebhhbrffruignwiugnbrwuiwhnriufniugvwhnruignwurighnwigvuwrhugirnhgiuwnriwiurwnhiughwpiu9348"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "your-issuer",
            audience: "your-audience",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7), // Token expiration
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string HashPassword(string? password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }

    
}