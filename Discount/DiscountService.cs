
public class DiscountService : IDiscountService {
    private readonly IDiscountRepository _discountRepository;
    public DiscountService(IDiscountRepository discountRepository) {
        _discountRepository = discountRepository;
    }

    public bool Create(Discount discount)
    {
        return _discountRepository.Create(discount);
    }

    public bool Delete(int id)
    {
        return _discountRepository.Delete(id);
    }

    public bool Exists(int id)
    {
        return _discountRepository.Exists(id);
    }

    public ICollection<Discount> GetAll()
    {
        return _discountRepository.GetAll();
    }

    public Discount GetById(int id)
    {
        return _discountRepository.GetById(id);
    }

    public bool Save()
    {
        return _discountRepository.Save();
    }
}