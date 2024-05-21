
public class CartRepository : ICartRepository {
    private readonly DataContext _dataContext;
    public CartRepository(DataContext dataContext) {
        _dataContext = dataContext;
    }

    public bool Create(Cart cart)
    {
        _dataContext.Carts.Add(cart);
        return Save();
    }

    public bool Exists(int id)
    {
        return _dataContext.Carts.Any(c => c.Id == id);
    }

    public ICollection<Cart> GetAll()
    {
        return _dataContext.Carts.OrderBy(c => c.Id).ToList();
    }

    public Cart GetByCustomerId(int customerId)
    {
        return _dataContext.Carts.Where(c => c.CustomerId == customerId).FirstOrDefault();
    }

    public Cart GetById(int id)
    {
        return _dataContext.Carts.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _dataContext.SaveChanges();
        return saved > 0 ? true : false;
    }
}