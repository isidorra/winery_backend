public class CartProduct
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public Cart? Cart { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }

    public CartProduct() {}
    public CartProduct(CartProductDto cartProductDto) {
        this.CartId = cartProductDto.CartId;
        this.ProductId = cartProductDto.ProductId;
        this.Quantity = cartProductDto.Quantity;
    }
}