namespace winery_backend.ViewLogisticsEmployees.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.Services;
    using winery_backend.ViewLogisticsEmployees.Dto;
    using winery_backend.ViewWarehouse.Interface;

    [Route("api/logistician/employees")]
    [ApiController]
    public class ViewLogisticsEmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ISectorService _sectorService;
        public ViewLogisticsEmployeesController(IEmployeeService employeeService, ISectorService sectorService)
        {
            _employeeService = employeeService;
            _sectorService = sectorService;
        }

        [HttpGet]
        public IActionResult GetAllLogisticsEmployees()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            List<Employee> warehouseWorkers = _employeeService.FindAllWarehouseWorkers();

            List<WarehouseWorkerDto> warehouseWorkersDtos = new List<WarehouseWorkerDto>();

            foreach(Employee warehouseman in  warehouseWorkers)
            {
                warehouseWorkersDtos.Add(new WarehouseWorkerDto(warehouseman.Id, warehouseman.Firstname, warehouseman.Lastname, warehouseman.Email));
            }

            List<Employee> vanDrivers = _employeeService.FindAllVanDrivers();

            List<VanDriverDto> vanDriverDtos = new List<VanDriverDto>();

            foreach (Employee vanDriver in vanDrivers)
            {
                vanDriverDtos.Add(new VanDriverDto(vanDriver.Id, vanDriver.Firstname, vanDriver.Lastname, vanDriver.Email));
            }

            LogisticsEmployeesDto logisticsEmployeesDto = new LogisticsEmployeesDto(warehouseWorkersDtos, vanDriverDtos);

            return Ok(logisticsEmployeesDto);
        }

        [HttpGet("singleEmployee")]
        public IActionResult GetSingleEmployee(int employeeId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Employee employee = _employeeService.FindById(employeeId);

            if(employee.Role.Equals(Role.WAREHOUSEMAN))
            {
                string sectorName = _sectorService.FindSectorNameByWarehousemanId(employee.Id);
                WarehouseWorkerViewDto warehouseWorkerViewDto = new WarehouseWorkerViewDto(employee, sectorName);
                return Ok(warehouseWorkerViewDto);
            }
            else
            {
                VanDriverViewDto vanDriverViewDto = new VanDriverViewDto(employee);
                return Ok(vanDriverViewDto);
            }
        }
    }
}
