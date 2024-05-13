namespace winery_backend.LogisticianManufacturingOrder.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public List<int> SupplierProductIds {  get; set; }

        public Supplier()
        {

        }

        public Supplier(int supplierId, string supplierName, string supplierAddress, List<int> supplierProductIds)
        {
            SupplierId = supplierId;
            SupplierName = supplierName;
            SupplierAddress = supplierAddress;
            SupplierProductIds = supplierProductIds;
        }
    }
}
