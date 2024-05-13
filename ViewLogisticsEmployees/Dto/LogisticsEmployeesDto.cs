namespace winery_backend.ViewLogisticsEmployees.Dto
{
    public class LogisticsEmployeesDto
    {
        public List<WarehouseWorkerDto> WarehouseWorkers { get; set; }
        public List<VanDriverDto> VanDrivers { get; set; }

        public LogisticsEmployeesDto()
        {

        }

        public LogisticsEmployeesDto(List<WarehouseWorkerDto> warehouseWorkers, List<VanDriverDto> vanDrivers)
        {
            WarehouseWorkers = warehouseWorkers;
            VanDrivers = vanDrivers;
        }
    }
}
