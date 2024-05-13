namespace winery_backend.Machine
{
    public class MachineOrder
    {
        public Guid Id { get; set; }
        public Machine Machine { get; set; }
        public int MachineId { get; set; }
        public long Amount { get; set; }
        public MachineOrder() { }
        public MachineOrder(Guid id, Machine machine, int machineId, long amount)
        {
            Id = id;
            Machine = machine;
            MachineId = machineId;
            Amount = amount;
        }
    }
}
