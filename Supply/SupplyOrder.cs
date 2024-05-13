namespace winery_backend.Invetory
{
    public class SupplyOrder
    {
        public Guid Id { get; set; }
        public Supply Supply { get; set; }
        public int SupplyId { get; set; }
        public long Amount { get; set; }
        public SupplyOrder() { }

        public SupplyOrder(Guid id, Supply supply, int supplyId, long amount)
        {
            Id = id;
            Supply = supply;
            SupplyId = supplyId;
            Amount = amount;
        }
    }
}
