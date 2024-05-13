public class Discount
{
    public int Id { get; set; }
    public double Percentage { get; set; }

    public Discount() { }
    public Discount(CreateDiscountDto createDiscountDto)
    {
        this.Percentage = createDiscountDto.Percentage;
    }
}