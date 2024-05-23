public interface ICartService {
    ICollection<Cart> GetAll();
    Cart GetById(int id);
    Cart GetByCustomerId(int customerId);
    Cart GetByCustomerUsername(string username);
    bool Exists(int id);
    bool Create(Cart cart);
    bool Save();
    double CalculateTotal(int cartId);
}