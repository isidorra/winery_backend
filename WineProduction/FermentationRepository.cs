using winery_backend.WineProduction.Interface;

namespace winery_backend.WineProduction
{
    public class FermentationRepository : IFermentationRepository
    {
        private readonly DataContext _context;

        public FermentationRepository(DataContext context)
        {
            _context = context;
        }

        public bool Create(Fermentation fermentation)
        {
            _context.Add(fermentation);
            return Save();
        }

        public ICollection<Fermentation> GetAll()
        {
            return _context.Fermentations.OrderBy(f => f.Id).ToList();
        }

        public Fermentation GetById(int id)
        {
            return _context.Fermentations.Where(f => f.Id.Equals(id)).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public void Update(Fermentation fermentation)
        {
            var editedFermentation = _context.Fermentations.FirstOrDefault(a => a.Id == fermentation.Id);
            if (editedFermentation == null)
            {
                throw new ArgumentException("Fermentation not found");
            }

            try
            {
                _context.Update(fermentation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit fermentation", ex);
            }
        }
    }
}
