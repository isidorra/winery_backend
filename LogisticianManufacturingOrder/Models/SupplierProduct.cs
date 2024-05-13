using winery_backend.LogisticianManufacturingOrder.Enum;

namespace winery_backend.LogisticianManufacturingOrder.Models
{
    public class SupplierProduct
    {
        public int SupplierProductId { get; set; }
        public string SupplierProductName { get; set; }
        public decimal SupplierProductPrice { get; set; }
        public string SupplierProductManufacturer { get; set; }
        public int SupplierProductAmount { get; set; }
        public SupplierProductType Type { get; set; }

        public SupplierProduct()
        {

        }

        public SupplierProduct(int supplierProductId, string supplierProductName, decimal supplierProductPrice, string supplierProductManufacturer, int supplierProductAmount, SupplierProductType supplierProductType)
        {
            SupplierProductId = supplierProductId;
            SupplierProductName = supplierProductName;
            SupplierProductPrice = supplierProductPrice;
            SupplierProductManufacturer = supplierProductManufacturer;
            SupplierProductAmount = supplierProductAmount;
            Type = supplierProductType;
        }
    }
}
