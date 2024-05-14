
public class PricingService : IPricingService
{
    private readonly IPricingRepository _pricingRepository;
    public PricingService(IPricingRepository pricingRepository) {
        _pricingRepository = pricingRepository;
    }

    public bool Create(Pricing pricing)
    {
        return _pricingRepository.Create(pricing);
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

    public bool Save()
    {
        return _pricingRepository.Save();
    }

    public void Update(Pricing newPricing)
    {
        try
            {
                Pricing pricing = _pricingRepository.GetById(newPricing.Id);
                if (newPricing.Price != 0)
                {
                    pricing.Price = newPricing.Price;
                }

                _pricingRepository.Update(pricing);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit pricing", ex);
            }
    }

    public double? FindById(int? pricingId)
    {
        return _pricingRepository.FindById(pricingId);
    }
}