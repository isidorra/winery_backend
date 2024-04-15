
using Microsoft.AspNetCore.Mvc;

[Route("/api")]
[ApiController]
public class AuthController : Controller {
    private readonly IAuthService _authService;
    private readonly ICustomerService _customerService;
    public AuthController(IAuthService authService, ICustomerService customerService) {
        _authService = authService;
        _customerService = customerService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterCustomerDto registerCustomerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string hashedPassword = _authService.HashPassword(registerCustomerDto.Password);

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

        var token = _authService.GenerateJwtToken(customer);

        return Ok(new { Token = token });

    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        var customer = _customerService.Authenticate(loginDto.Username, loginDto.Password);

        if (customer == null)
        {
            // Unauthorized if authentication fails
            return Unauthorized();
        }

        // Generate JWT token
        var token = _authService.GenerateJwtToken(customer);

        // Return token
        return Ok(new { Token = token });
    }
}