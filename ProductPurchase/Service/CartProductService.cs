
public class CartProductService : ICartProductService {
    private readonly ICartProductRepository _cartProductRepository;
    public CartProductService(ICartProductRepository cartProductRepository) {
        _cartProductRepository = cartProductRepository;
    }

    public bool Create(CartProduct cartProduct)
    {
        return _cartProductRepository.Create(cartProduct);
    }

    public bool Delete(int id)
    {
        return _cartProductRepository.Delete(id);
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

    public void Update(CartProduct cartProduct)
    {
        try
        {
            CartProduct cartProduct1 = _cartProductRepository.GetById(cartProduct.Id);
            if (cartProduct.Quantity != 0)
            {
                cartProduct1.Quantity = cartProduct.Quantity;
            }

            _cartProductRepository.Update(cartProduct1);
        }
        catch (Exception ex)
        {
            throw new Exception("Error while trying to edit cart product", ex);
        }
    }
}