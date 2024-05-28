using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using winery_backend.Grapes.Interface;

namespace winery_backend.Grapes
{
    public class GrapeRepository : IGrapeRepository
    {
        private readonly DataContext _context;

        public GrapeRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Grape> GetAll()
        {
            return _context.Grapes.OrderBy(g => g.Id).ToList();
        }

        public Grape GetById(int id)
        {
            return _context.Grapes.Where(g => g.Id == id).FirstOrDefault();
        }

        public Grape GetByName(string name)
        {
            return _context.Grapes.Where(g => g.Name.Equals(name)).FirstOrDefault();
        }

        public void Update(Grape grape)
        {
            var editedGrape = _context.Grapes.FirstOrDefault(g => g.Id == grape.Id);
            if (editedGrape == null)
            {
                throw new ArgumentException("Grape not found");
            }

            try
            {
                _context.Update(grape);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit grape", ex);
            }
        }
    }
}
