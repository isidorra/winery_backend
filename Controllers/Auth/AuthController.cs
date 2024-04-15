
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

[Route("/api")]
[ApiController]
public class AuthController : Controller {
    private readonly IAuthService _authService;
    private readonly ICustomerService _customerService;
    private readonly IUserService _userService;

    public JwtSecurityToken globalToken = null;

    public AuthController(IAuthService authService, ICustomerService customerService, IUserService userService) {
        _authService = authService;
        _customerService = customerService;
        _userService = userService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterCustomerDto registerCustomerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string hashedPassword = _authService.HashPassword(registerCustomerDto.Password);

        Customer customer = new Customer(registerCustomerDto, hashedPassword);

        _customerService.Create(customer);

        var token = _authService.GenerateJwtToken(customer);

        return Ok(new { Token = token });

    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        User user = _userService.Authenticate(loginDto.Username, loginDto.Password);

        if (user == null)
        {
            // Unauthorized if authentication fails
            return Unauthorized();
        }

        // Generate JWT token
        var token = _authService.GenerateJwtToken(user);

        globalToken = _authService.GenerateJwtTokenObject(user);

        Console.WriteLine(globalToken.ToString());

        // Return token
        return Ok(new { Token = token });
    }

    [HttpPost("employeeRegister")]
    public IActionResult EmployeeRegister(RegisterEmployeeDto registerEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // FALI: provera da li je administrator onaj koji hoce da ih registruje
        // KOMENTAR: pitanje je da li to i treba, jer ce on na frontend-u biti ulogovan kao administrator, niko drugi nece ni moci da dodje do ovog dela osim njega

        /*if(globalToken.Equals(Role.ADMINISTRATOR))
        {*/
        string hashedPassword = _authService.HashPassword(registerEmployeeDto.Password);

        Employee employee = new Employee(registerEmployeeDto, hashedPassword);

        _userService.CreateEmployee(employee);

        var token = _authService.GenerateJwtToken(employee);

        return Ok(new { Token = token });
        //}

    }

}