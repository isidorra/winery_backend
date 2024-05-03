public interface IProductService {
    ICollection<Product> GetAll();
    Product GetById(int id);
    ICollection<Product> GetByCategoryId(int categoryId);
    bool Exists(int id);
    ICollection<Product> Search(string keyword);
}