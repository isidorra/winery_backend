
public class CartService : ICartService {
    private readonly ICartRepository _cartRepository;
    public CartService(ICartRepository cartRepository) {
        _cartRepository = cartRepository;
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

    public Cart GetById(int id)
    {
        return _cartRepository.GetById(id);
    }

    public bool Save()
    {
        return _cartRepository.Save();
    }
}