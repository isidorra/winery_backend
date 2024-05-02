using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using winery_backend.Services;


[Route("api/employees")]
[ApiController]
public class EmployeeController : Controller
 {
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService) 
    { 
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetAll() {
        var employees = _employeeService.GetAll();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(employees);
    }

    [HttpGet("username")]
    public IActionResult GetByUsername(string username) {
        if(_employeeService.GetByUsername(username) == null)
            return BadRequest("Customer does not exist");
        var employee = _employeeService.GetByUsername(username);

        // if (!ModelState.IsValid)
        //     return BadRequest(ModelState);

        return Ok(employee);
    }

    [HttpGet("view/employee")]
    public IActionResult View()
    {
        var employeeId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (employeeId == null)
        {
            return Unauthorized();
        }

        Employee employee = _employeeService.GetByUsername(employeeId);

        return View(employee);
    }

    [HttpPost("edit/employee/username")]
    public IActionResult Edit(EditEmployeeDto editEmployeeDto, string username)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var employee = _employeeService.GetByUsername(username);
        if (employee == null)
            return Unauthorized();

        try
        {
            _employeeService.Update(editEmployeeDto, employee.Id);
            return Ok("Successful edit");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error : {ex.Message}");
        }


    }
}

