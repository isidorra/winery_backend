public class PurchasedProduct
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public PurchasedProduct() {}
    public PurchasedProduct(CreatePurchasedProductDto createPurchasedProductDto) {
        this.PurchaseId = createPurchasedProductDto.ProductId;
        this.ProductId = createPurchasedProductDto.ProductId;
        this.Quantity = createPurchasedProductDto.Quantity;
    }
}