using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/customers")]
[ApiController]
public class CustomerController : Controller
{

    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {

        _customerService = customerService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _customerService.GetAll();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(customers);
    }

    [HttpGet("{userId}")]
    public IActionResult GetById(int userId)
    {

        if (!_customerService.Exists(userId))
        {
            return BadRequest("Customer do not exist");
        }
        var customer = _customerService.GetById(userId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(customer);
    }

    private string HashPassword(string? password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();

        // Hash the password using the salt
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        return hashedPassword;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterCustomerDto registerCustomerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string hashedPassword = HashPassword(registerCustomerDto.Password);

        var customer = new Customer
        {
            Firstname = registerCustomerDto.Firstname,
            Lastname = registerCustomerDto.Lastname,
            Email = registerCustomerDto.Email,
            Username = registerCustomerDto.Username,
            Password = hashedPassword,
            Gender = registerCustomerDto.Gender,
            Role = Role.CUSTOMER,
            PhoneNumber = registerCustomerDto.PhoneNumber,
            BirthDate = registerCustomerDto.BirthDate
        };

        _customerService.Create(customer);

        var token = GenerateJwtToken(customer);

        return Ok(new { Token = token });

    }

    private object GenerateJwtToken(Customer customer)
    {
        // Create claims based on customer's information (e.g., username, ID, role, etc.)
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
        new Claim(ClaimTypes.Name, customer.Username),
        // Add other claims as needed
    };

        // Create symmetric security key
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your-secret-key"));

        // Create signing credentials using the key
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Create JWT token
        var token = new JwtSecurityToken(
            issuer: "your-issuer",
            audience: "your-audience",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7), // Token expiration
            signingCredentials: creds
        );

        // Return JWT token as a string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}