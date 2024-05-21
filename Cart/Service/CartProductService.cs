
public class CartProductService : ICartProductService {
    private readonly ICartProductRepository _cartProductRepository;
    public CartProductService(ICartProductRepository cartProductRepository) {
        _cartProductRepository = cartProductRepository;
    }

    public bool Create(CartProduct cartProduct)
    {
        return _cartProductRepository.Create(cartProduct);
    }

    public bool Exists(int id)
    {
        return _cartProductRepository.Exists(id);
    }

    public ICollection<CartProduct> GetAll()
    {
        return _cartProductRepository.GetAll();
    }

    public ICollection<CartProduct> GetAllByCartId(int cartId)
    {
        return _cartProductRepository.GetAllByCartId(cartId);
    }

    public CartProduct GetById(int id)
    {
        return _cartProductRepository.GetById(id);
    }

    public bool Save()
    {
        return _cartProductRepository.Save();
    }
}