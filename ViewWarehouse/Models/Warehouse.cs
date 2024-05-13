namespace winery_backend.ViewWarehouse.Models
{
    public class Warehouse
    {
        public int WarehouseId {  get; set; }
        public string WarehouseName { get; set; }
        public decimal WarehouseArea {  get; set; }
        public string WarehouseLocation { get; set; }
        public int NumberOfWarehouseWorkers {  get; set; }
        public int NumberOfVanDrivers { get; set; }
        public int NumberOfSectors { get; set; }
        public string WarehouseImage {  get; set; }

        public Warehouse()
        {

        }

        public Warehouse(int warehouseId, string warehouseName, decimal warehouseArea, string warehouseLocation, int numberOfWarehouseWorkers, int numberOfVanDrivers, int numberOfSectors, string warehouseImage)
        {
            WarehouseId = warehouseId;
            WarehouseName = warehouseName;
            WarehouseArea = warehouseArea;
            WarehouseLocation = warehouseLocation;
            NumberOfWarehouseWorkers = numberOfWarehouseWorkers;
            NumberOfVanDrivers = numberOfVanDrivers;
            NumberOfSectors = numberOfSectors;
            WarehouseImage = warehouseImage;
        }
    }
}
