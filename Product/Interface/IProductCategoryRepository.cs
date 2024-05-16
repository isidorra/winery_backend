public interface IProductCategoryRepository {
    ICollection<ProductCategory> GetAll();
    ProductCategory GetById(int id);
    bool Exists(int id);
    string FindById(int? productCategoryId);
}