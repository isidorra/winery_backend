public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Photo { get; set; }
    public int? Quantity { get; set; }
    public bool? IsApproved { get; set; }
    public int? PricingId { get; set; }
    public Pricing? Pricing { get; set; }
    public int? ProductCategoryId { get; set; }
    public ProductCategory? ProductCategory { get; set; }
}