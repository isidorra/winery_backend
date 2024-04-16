
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using winery_backend.Services;

[Route("/api")]
[ApiController]
public class AuthController : Controller {
    private readonly IAuthService _authService;
    private readonly ICustomerService _customerService;
    private readonly IEmployeeService _employeeService;

    public JwtSecurityToken globalToken = null;

    public AuthController(IAuthService authService, ICustomerService customerService, IEmployeeService employeeService) {
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

        var token = _authService.GenerateJwtToken(customer);

        return Ok(new { Token = token });
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDto loginDto)
    {
        if(string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
        {
            return BadRequest(ModelState);
        }

        Customer customer = _customerService.Authenticate(loginDto.Username, loginDto.Password);
        Employee employee = _employeeService.Authenticate(loginDto.Username, loginDto.Password);

        // GLOBALNI TOKEN TREBA NAPRAVITI NEKAKO, DA BI SE MOGLE PROVERITI ROLE, I DA BI SE POSLE MOGAO UNISTITI TOKEN KADA SE IZLOGUJE
        /*globalToken = _authService.GenerateJwtTokenObject(customer);
        Console.WriteLine(globalToken.ToString());*/

        if (customer != null)
        {
            // Generate JWT token
            var token = _authService.GenerateJwtToken(customer);

            // Return token
            return Ok(new { Token = token });
        }
        else if (employee != null)
        {
            // Generate JWT token
            var token = _authService.GenerateJwtToken(employee);

            // Return token
            return Ok(new { Token = token });
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

        var token = _authService.GenerateJwtToken(employee);

        return Ok(new { Token = token });

        // FALI: provera da li je administrator onaj koji hoce da ih registruje
        // KOMENTAR: pitanje je da li to i treba, jer ce on na frontend-u biti ulogovan kao administrator, niko drugi nece ni moci da dodje do ovog dela osim njega
        /*if(globalToken.Equals(Role.ADMINISTRATOR))*/

    }

}