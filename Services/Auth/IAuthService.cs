using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

public interface IAuthService {
    
    string HashPassword(string? password);

}