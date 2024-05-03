
public class PricingService : IPricingService
{
    private readonly IPricingRepository _pricingRepository;
    public PricingService(IPricingRepository pricingRepository) {
        _pricingRepository = pricingRepository;
    }

    public bool Exists(int id)
    {
        return _pricingRepository.Exists(id);
    }

    public ICollection<Pricing> GetAll()
    {
        return _pricingRepository.GetAll();
    }

    public Pricing GetById(int id)
    {
        return _pricingRepository.GetById(id);
    }
}