
    public class SupplyOrder
    {
        public Guid Id { get; set; }
        //public Supply Supply { get; set; }
        //public int SupplyId { get; set; }

        public List<int> SupplierSupplyIds { get; set; }
        public long Amount { get; set; }
        public DateTime SupplyOrderCreationTime { get; set; }
        public int DaysUntilDelivery { get; set; }
        public bool Completed {  get; set; }
        public int SupplierId {  get; set; }

        public SupplyOrder() { }

        public SupplyOrder(Guid id, List<int> supplierSupplyIds, long amount, DateTime supplyOrderCreationTime, int daysUntilDelivery, bool completed, int supplierId)
        {
            Id = id;
            SupplierSupplyIds = supplierSupplyIds;
            Amount = amount;
            SupplyOrderCreationTime = supplyOrderCreationTime;
            DaysUntilDelivery = daysUntilDelivery;
            Completed = completed;
            SupplierId = supplierId;
        }
    }

