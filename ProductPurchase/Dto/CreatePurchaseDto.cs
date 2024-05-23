public class CreatePurchaseDto
{
    public int CustomerId { get; set; }
    public double Total { get; set; }
    public string Note { get; set; }
    public List<CartProduct> CartProducts { get; set; }
}