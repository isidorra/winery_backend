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
    public decimal PackagingSize { get; set; }
    public decimal AlcoholPercentage { get; set; }
    public int SectorId { get; set; }

    public Product()
    {

    }

    public Product(int id, string? name, string? description, string? photo, int? quantity, bool? isApproved, int? pricingId, Pricing? pricing, int? productCategoryId, ProductCategory? productCategory, decimal packagingSize, decimal alcoholPercentage, int sectorId)
    {
        Id = id;
        Name = name;
        Description = description;
        Photo = photo;
        Quantity = quantity;
        IsApproved = isApproved;
        PricingId = pricingId;
        Pricing = pricing;
        ProductCategoryId = productCategoryId;
        ProductCategory = productCategory;
        PackagingSize = packagingSize;
        AlcoholPercentage = alcoholPercentage;
        SectorId = sectorId;
    }
}