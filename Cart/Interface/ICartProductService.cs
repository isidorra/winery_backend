public interface ICartProductService {
    ICollection<CartProduct> GetAll();
    ICollection<CartProduct> GetAllByCartId(int cartId);
    CartProduct GetById(int id);
    bool Exists(int id);
    bool Create(CartProduct cartProduct);
    bool Save();
}