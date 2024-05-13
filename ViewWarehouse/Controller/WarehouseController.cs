namespace winery_backend.ViewWarehouse.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Dto;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.Services;
    using winery_backend.ViewWarehouse.Dto;
    using winery_backend.ViewWarehouse.Interface;
    using winery_backend.ViewWarehouse.Models;

    [Route("api/logistician/warehouse")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly ISectorService _sectorService;
        private readonly IEmployeeService _employeeService;
        public WarehouseController(IWarehouseService warehouseService, ISectorService sectorService, IEmployeeService employeeService)
        {
            _warehouseService = warehouseService;
            _sectorService = sectorService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetInformationAllSectors()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Warehouse warehouse = _warehouseService.FindWarehouse();

            List<SectorDto> sectorDtos = new List<SectorDto>();

            List<Sector> sectors = _sectorService.FindAllSectors(warehouse.WarehouseId);

            foreach(Sector sector in sectors)
            {
                Employee warehouseman = _employeeService.FindById(sector.WarehousemanId);
                sectorDtos.Add(new SectorDto(sector.SectorName, warehouseman.Username));
            }

            WarehouseAndSectorsViewDto warehouseAndSectorsViewDto = new WarehouseAndSectorsViewDto(warehouse, sectorDtos);

            return Ok(warehouseAndSectorsViewDto);
        }
    }
}
