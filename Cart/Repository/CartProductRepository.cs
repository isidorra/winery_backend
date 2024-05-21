
public class CartProductRepository : ICartProductRepository {
    private readonly DataContext _context;
    public CartProductRepository(DataContext context) {
        _context = context;
    }

    public bool Create(CartProduct cartProduct)
    {
        _context.CartProducts.Add(cartProduct);
        return Save();
    }

    public bool Exists(int id)
    {
        return _context.CartProducts.Any(c => c.Id == id);
    }

    public ICollection<CartProduct> GetAll()
    {
        return _context.CartProducts.OrderBy(c => c.Id).ToList();
    }

    public ICollection<CartProduct> GetAllByCartId(int cartId)
    {
        return _context.CartProducts
                .Where(c => c.CartId == cartId) // Filter by cartId
                .OrderBy(c => c.Id)
                .ToList();            
    }

    public CartProduct GetById(int id)
    {
        return _context.CartProducts.Where(c => c.Id == id).FirstOrDefault();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }
}