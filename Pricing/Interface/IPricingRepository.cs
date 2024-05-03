using System.Collections.ObjectModel;

public interface IPricingRepository {
    ICollection<Pricing> GetAll();
    Pricing GetById(int id);
    bool Exists(int id);
}