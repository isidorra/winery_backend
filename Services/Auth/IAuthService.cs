using Microsoft.AspNetCore.Mvc;

public interface IAuthService {
    string GenerateJwtToken(Customer customer);
    string HashPassword(string? password);

}