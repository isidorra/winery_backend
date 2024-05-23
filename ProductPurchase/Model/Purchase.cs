public class Purchase
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public double Total { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Note { get; set; }
    public PurchaseStatus PurchaseStatus { get; set; }

    public Purchase() {}
    public Purchase(CreatePurchaseDto createPurchaseDto) {
        this.CustomerId = createPurchaseDto.CustomerId;
        this.Total = createPurchaseDto.Total;
        this.CreatedAt = DateTime.Today;
        this.Note = createPurchaseDto.Note;
        this.PurchaseStatus = PurchaseStatus.PROCESSING;
    } 
}