
public class CartService : ICartService {
    private readonly ICartRepository _cartRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly ICartProductRepository _cartProductRepository;
    private readonly IProductRepository _productRepository;
    private readonly IPricingRepository _pricingRepository;
    private readonly IDiscountRepository _discountRepository;
    public CartService(ICartRepository cartRepository, ICustomerRepository customerRepository, ICartProductRepository cartProductRepository, IProductRepository productRepository, IPricingRepository pricingRepository, IDiscountRepository discountRepository) {
        _cartRepository = cartRepository;
        _customerRepository = customerRepository;
        _cartProductRepository = cartProductRepository;
        _productRepository = productRepository;
        _pricingRepository = pricingRepository;
        _discountRepository = discountRepository;
    }

    public double CalculateTotal(int cartId)
    {
        double total = 0;
        List<CartProduct> cartProducts = _cartProductRepository.GetAllByCartId(cartId).ToList();

        foreach(CartProduct cartProduct in cartProducts) {
            Product product = _productRepository.GetById(cartProduct.ProductId);
            Pricing pricing = _pricingRepository.GetById(product.PricingId.Value);
            
            if(pricing.DiscountId != null) {
                Discount discount = _discountRepository.GetById(pricing.DiscountId.Value);
                total += (1 - discount.Percentage / 100.0) * pricing.Price.Value * cartProduct.Quantity;
            } else {
                total += cartProduct.Quantity * pricing.Price.Value;
            }    
        }

        return total;
    }

    public bool Create(Cart cart)
    {
        return _cartRepository.Create(cart);
    }

    public bool Exists(int id)
    {
        return _cartRepository.Exists(id);
    }

    public ICollection<Cart> GetAll()
    {
        return _cartRepository.GetAll();
    }

    public Cart GetByCustomerId(int customerId)
    {
        return _cartRepository.GetByCustomerId(customerId);
    }

    public Cart GetByCustomerUsername(string username)
    {
        Customer customer = _customerRepository.GetByUsername(username);
        return _cartRepository.GetByCustomerId(customer.Id);
    }

    public Cart GetById(int id)
    {
        return _cartRepository.GetById(id);
    }

    public bool Save()
    {
        return _cartRepository.Save();
    }

   
}