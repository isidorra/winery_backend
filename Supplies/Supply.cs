namespace Supplies
{
    public class Supply
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SupplyType SupplyType { get; set; }
        public long Amount { get; set; }
        public string Manufacturer { get; set; }
        public Supply() { }
        public Supply(int id, string name, SupplyType supplyType, long amount, string manufacturer)
        {
            Id = id;
            Name = name;
            SupplyType = supplyType;
            Amount = amount;
            Manufacturer = manufacturer;
        }


    }

}