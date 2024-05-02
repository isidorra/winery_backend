using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

public interface IAuthService {
    string GenerateJwtToken(User user);

    JwtSecurityToken GenerateJwtTokenObject(User user);
    string HashPassword(string? password);

}