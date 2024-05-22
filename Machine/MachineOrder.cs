namespace winery_backend.Machines
{
    public class MachineOrder
    {
        public Guid Id { get; set; }
        //public Machine Machine { get; set; }
        //public int MachineId { get; set; }
        public List<int> SupplierMachineIds { get; set; }
        public long Amount { get; set; }
        public DateTime MachineOrderCreationTime {  get; set; }
        public int DaysUntilDelivery { get; set; }
        public bool Completed { get; set; }
        public int SupplierId { get; set; }

        public MachineOrder() { }

        public MachineOrder(Guid id, List<int> supplierMachineIds, long amount, DateTime machineOrderCreationTime, int daysUntilDelivery, bool completed, int supplierId)
        {
            Id = id;
            SupplierMachineIds = supplierMachineIds;
            Amount = amount;
            MachineOrderCreationTime = machineOrderCreationTime;
            DaysUntilDelivery = daysUntilDelivery;
            Completed = completed;
            SupplierId = supplierId;
        }
    }
}
