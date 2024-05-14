public interface IProductRepository {
    ICollection<Product> GetAll();
    Product GetById(int id);
    ICollection<Product> GetByCategoryId(int categoryId);
    bool Exists(int id);
    ICollection<Product> Search(string keyword);
    public void Update(Product product);
    List<Product> FindProductsByCustomerOrderId(List<int> productIds);
    int FindProductSectorIdByProductId(int id);
    List<Product> FindProductsBySectorId(int sectorId);
    string FindProductNameById(int productId);
    void UpdateProductQuantity(Product product);
    Product FindProductByProductName(string productName);
}