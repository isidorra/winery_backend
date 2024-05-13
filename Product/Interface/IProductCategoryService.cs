public interface IProductCategoryService {
    ICollection<ProductCategory> GetAll();
    ProductCategory GetById(int id);
    bool Exists(int id);
}