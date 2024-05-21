public class Pricing
{
    public int Id { get; set; }
    public double? Price { get; set; }
    public int? DiscountId { get; set; }
    public virtual Discount? Discount { get; set; }

    public Pricing() { }
    public Pricing(CreatePriceDto createPriceDto)
    {
        this.Price = createPriceDto.Price;
    }
    public Pricing(UpdatePriceDto updatePriceDto)
    {
        this.Id = updatePriceDto.Id;
        this.Price = updatePriceDto.Price;
    }
}