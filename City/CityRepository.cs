
public class CityRepository : ICityRepository
{
    private readonly DataContext _context;
    public CityRepository(DataContext context) {
        _context = context;
    }
    public ICollection<City> GetAll()
    {
        return _context.Cities.OrderBy(c => c.Id).ToList();
    }

    public City GetById(int id)
    {
        return _context.Cities.Where(c => c.Id == id).FirstOrDefault();
    }
}