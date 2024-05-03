public interface IProductRepository {
    ICollection<Product> GetAll();
    Product GetById(int id);
    bool Exists(int id);
}