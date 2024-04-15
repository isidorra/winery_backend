using Microsoft.AspNetCore.Mvc;


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

   
    

   



}