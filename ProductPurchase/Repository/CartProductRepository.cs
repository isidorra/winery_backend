
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

    public bool Delete(int id)
    {
        var cartProductToDelete = _context.CartProducts.FirstOrDefault(d => d.Id == id);

        if (cartProductToDelete != null)
        {
            _context.CartProducts.Remove(cartProductToDelete);
            _context.SaveChanges();
            return true; 
        }

        return false;
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
                .Where(c => c.CartId == cartId)
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

    public void Update(CartProduct cartProduct)
    {
        var edited = _context.CartProducts.FirstOrDefault(p => p.Id == cartProduct.Id);
        if (edited == null)
            throw new ArgumentException("Cart product not found");

        try
        {
            _context.Update(edited);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Error while trying to edit cart product", ex);
        }
    }
}