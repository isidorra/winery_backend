public interface ICityService {
    ICollection<City> GetAll();
    City GetById(int id);
}