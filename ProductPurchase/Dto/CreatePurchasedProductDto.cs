public class CreatePurchasedProductDto {
    public int PurchaseId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public CreatePurchasedProductDto() {}
    public CreatePurchasedProductDto(int purchaseId, int productId, int quantity) {
        this.ProductId = productId;
        this.PurchaseId = purchaseId;
        this.Quantity = quantity;
    }
}