using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/employees")]
[ApiController]
public class EmployeeController : Controller
 {
    private readonly IEmployeeService _employeeService;
    public EmployeeController(IEmployeeService employeeService) 
    { 
        _employeeService = employeeService;
    }
    [HttpGet("view/employee")]
    [Authorize]
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

    [HttpPost("edit/employee")]
    [Authorize]
    public IActionResult Edit(EditEmployeeDto editEmployeeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var employeeId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (employeeId == null)
        {
            return Unauthorized();
        }

        try
        {
            _employeeService.Update(editEmployeeDto, int.Parse(employeeId));
            return Ok("Successful edit");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error : {ex.Message}");
        }


    }
}

