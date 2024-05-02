
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using winery_backend.Services;

[Route("/api")]
[ApiController]
public class AuthController : Controller
{
    private readonly IAuthService _authService;
    private readonly ICustomerService _customerService;
    private readonly IEmployeeService _employeeService;

    public JwtSecurityToken globalToken = null;

    public AuthController(IAuthService authService, ICustomerService customerService, IEmployeeService employeeService)
    {
        _authService = authService;
        _customerService = customerService;
        _employeeService = employeeService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterCustomerDto registerCustomerDto)
    {
        System.Diagnostics.Debug.WriteLine("wwwwwwwwwwww");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string hashedPassword = _authService.HashPassword(registerCustomerDto.Password);

        Customer customer = new Customer(registerCustomerDto, hashedPassword);

        if (!_customerService.Create(customer))
        {
            return BadRequest(ModelState);
        }


        return Ok(new { Username = customer.Username, Role = customer.Role });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
        {
            return BadRequest(ModelState);
        }

        Customer customer = _customerService.Authenticate(loginDto.Username, loginDto.Password);
        Employee employee = _employeeService.Authenticate(loginDto.Username, loginDto.Password);



        if (customer != null)
        {
            return Ok(new { Username = customer.Username, Role = customer.Role });
        }
        else if (employee != null)
        {
            return Ok(new { Username = employee.Username, Role = employee.Role });
        }

        // Unauthorized if authentication fails
        return Unauthorized();
    }

    [HttpPost("employeeRegister")]
    public IActionResult EmployeeRegister(RegisterEmployeeDto registerEmployeeDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        string hashedPassword = _authService.HashPassword(registerEmployeeDto.Password);

        Employee employee = new Employee(registerEmployeeDto, hashedPassword);

        if (!_employeeService.CreateEmployee(employee))
        {
            return BadRequest(ModelState);
        }

        return Ok("Successfully created employee.");

    }

}