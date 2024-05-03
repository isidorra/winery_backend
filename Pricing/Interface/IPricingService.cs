public interface IPricingService {
    ICollection<Pricing> GetAll();
    Pricing GetById(int id);
    bool Exists(int id);
}