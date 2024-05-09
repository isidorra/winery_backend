namespace winery_backend.ViewWarehouse.Models
{
    public class Warehouse
    {
        public int WarehouseId {  get; set; }
        public string? WarehouseName { get; set; }
        public decimal? WarehouseArea {  get; set; }
        public int? NumberOfWarehouseWorkers {  get; set; }
        public int? NumberOfVanDrivers { get; set; }
        public int? NumberOfSectors { get; set; }
        public string? WarehouseImage {  get; set; }



    }
}
