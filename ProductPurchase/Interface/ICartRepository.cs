public interface ICartRepository {
    ICollection<Cart> GetAll();
    Cart GetById(int id);
    Cart GetByCustomerId(int customerId);
    bool Exists(int id);
    bool Create(Cart cart);
    bool Save();
}