using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


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


    [HttpGet("username")]
    public IActionResult GetByUsername(string username) {
        if(_customerService.GetByUsername(username) == null)
            return BadRequest("Customer does not exist");
        var customer = _customerService.GetByUsername(username);

        // if (!ModelState.IsValid)
        //     return BadRequest(ModelState);

        return Ok(customer);
    }



    [HttpGet("{userId}")]
    public IActionResult GetById(int userId)
    {

        if (!_customerService.Exists(userId))
        {
            return BadRequest("Customer does not exist");
        }
        var customer = _customerService.GetById(userId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(customer);
    }



    [HttpGet("view/customer")]
    [Authorize]
    public IActionResult View()

    {
        var customerId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (customerId == null)
        {
            return Unauthorized();
        }

        Customer customer = _customerService.GetById(int.Parse(customerId));

        return View(customer);
    }



    [HttpPost("edit/customer/username")]
    public IActionResult Edit(EditCustomerDto editCustomerDto, string username)
    {

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var customer = _customerService.GetByUsername(username);
        if (customer == null)
            return Unauthorized();
        Console.WriteLine("USERNAME: ", username);
        try
        {
            _customerService.Update(editCustomerDto, customer.Id);
            return Ok("Successful edit");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error : {ex.Message}");
        }


    }






}