public interface IProductService {
    ICollection<Product> GetAll();
    Product GetById(int id);
    bool Exists(int id);
}