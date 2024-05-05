public interface IDiscountService {
    ICollection<Discount> GetAll();
    Discount GetById(int id);
    bool Exists(int id);
    bool Create(Discount discount);
    bool Save();
    bool Delete(int id);
}