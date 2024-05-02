
public class CityService : ICityService
{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository) {
        _cityRepository = cityRepository;
    }
    public ICollection<City> GetAll()
    {
        return _cityRepository.GetAll();
    }

    public City GetById(int id)
    {
        return _cityRepository.GetById(id);
    }
}