public interface IProductService {
    ICollection<Product> GetAll();
    ICollection<Product> GetApproved();
    Product GetById(int id);
    Product GetApprovedById(int id);
    ICollection<Product> GetByCategoryId(int categoryId);
    ICollection<Product> GetApprovedByCategoryId(int categoryId);
    bool Exists(int id);
    ICollection<Product> Search(string keyword);
    ICollection<Product> SearchApproved(string keyword);
    void Update(Product product);
    bool Approve(int productId);
    bool Disapprove(int productId);
}