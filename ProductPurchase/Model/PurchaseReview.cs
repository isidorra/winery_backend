public class PurchaseReview
{
    public int Id { get; set; }
    public int PurchaseId { get; set; }
    public double Review { get; set; }
    public PurchaseReview() {}
    public PurchaseReview(PurchaseReviewDto purchaseReviewDto) {
        this.PurchaseId = purchaseReviewDto.PurchaseId;
        this.Review = purchaseReviewDto.Review;
    }
}