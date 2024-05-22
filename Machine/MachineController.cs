using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Connections.Features;
using winery_backend.Machines.Interface;

namespace winery_backend.Machines
{
    [Route("api/machines")]
    [ApiController]
    public class MachineController : Controller
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var activities = _machineService.GetAll();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(activities);
        }


    }
}
