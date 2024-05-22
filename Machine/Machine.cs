namespace winery_backend.Machines
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Amount { get; set; }
        public bool MachineState { get; set; } // 1 is working, 0 is broken
        public string Manufacturer { get; set; }
        public int Total {  get; set; } // total number of machines
        public int Free {  get; set; } // amount of free machines

        public Machine()
        {
        }

        public Machine(int id, string name, long amount, bool machineState, string manufacturer, int total, int free)
        {
            Id = id;
            Name = name;
            Amount = amount;
            MachineState = machineState;
            Manufacturer = manufacturer;
            Total = total;
            Free = free;
        }
    }
}
