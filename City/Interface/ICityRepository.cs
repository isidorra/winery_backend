public interface ICityRepository {
    ICollection<City> GetAll();
    City GetById(int id);
}