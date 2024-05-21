public class Cart
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public Cart() {}
    public Cart(int customerId) {
        this.CustomerId = customerId;
    }

}