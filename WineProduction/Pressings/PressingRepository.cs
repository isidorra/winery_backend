using winery_backend.WineProduction.Fermentations;
using winery_backend.WineProduction.Pressings.Interface;

namespace winery_backend.WineProduction.Pressings
{
    public class PressingRepository : IPressingRepository
    {
        private readonly DataContext _context;

        public PressingRepository(DataContext context)
        {
            _context = context;
        }

        public bool Create(Pressing pressing)
        {
            _context.Add(pressing);
            return Save();
        }

        public ICollection<Pressing> GetAll()
        {
            return _context.Pressings.OrderBy(p => p.Id).ToList();
        }

        public Pressing GetById(int id)
        {
            return _context.Pressings.Where(p => p.Id.Equals(id)).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public void Update(Pressing pressing)
        {
            var editedPressing = _context.Pressings.FirstOrDefault(a => a.Id == pressing.Id);
            if (editedPressing == null)
            {
                throw new ArgumentException("Pressing not found");
            }

            try
            {
                _context.Update(pressing);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit pressing", ex);
            }
        }
    }
}
