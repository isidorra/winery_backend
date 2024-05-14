using System.Collections.ObjectModel;

public interface IPricingRepository {
    ICollection<Pricing> GetAll();
    Pricing GetById(int id);
    bool Exists(int id);
    bool Create(Pricing pricing);
    bool Save();
    void Update(Pricing pricing);
    double? FindById(int? pricingId);
}