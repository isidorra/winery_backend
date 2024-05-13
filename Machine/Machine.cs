namespace winery_backend.Machine
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; }
        public bool MachineState { get; set; } // 1 is working, 0 is broken
        public string Manufacturer { get; set; }

        public Machine()
        {
        }

        public Machine(int id, string name, long amount, bool machineState, string manufacturer)
        {
            Id = id;
            Name = name;
            Amount = amount;
            MachineState = machineState;
            Manufacturer = manufacturer;
        }
    }
}
