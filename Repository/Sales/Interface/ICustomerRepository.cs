public interface ICustomerRepository {
    ICollection<Customer> GetAll();
    Customer GetById(int id);
    Customer GetByUsername(string username);
    bool Exists(int id);
    bool Save();
    bool Create(Customer customer);


}