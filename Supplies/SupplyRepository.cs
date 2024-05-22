using Microsoft.AspNetCore.Mvc.TagHelpers;
using Supplies;
using System.Collections.ObjectModel;
using winery_backend.Supplies.Interface;

namespace winery_backend.Invetory
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly DataContext _context;

        public SupplyRepository(DataContext context)
        {
            _context = context;
        }

        public bool Create(Supply supply)
        {
            _context.Add(supply);
            return Save();
        }

        public ICollection<Supply> GetAll()
        {
            return _context.Supplies.OrderBy(s => s.Id).ToList();
        }

        public Supply GetById(int id)
        {
            return _context.Supplies.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public Supply GetByName(string name)
        {
            return _context.Supplies.Where(s => s.Name.Equals(name)).FirstOrDefault();
        }

        public ICollection<Supply> GetBySupplyType(SupplyType type)
        {
            ICollection<Supply> allSupplies = GetAll();
            ICollection<Supply> filteredSupplies = new Collection<Supply> ();
            foreach(Supply supply in allSupplies)
            {
                if(supply.SupplyType == type)
                {
                    filteredSupplies.Add(supply);
                }
            }
            return filteredSupplies;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public void Update(Supply supply)
        {
            var editedSupply = _context.Supplies.FirstOrDefault(s => s.Id == supply.Id);
            if (editedSupply == null)
            {
                throw new ArgumentException("Supply not found");
            }

            try
            {
                _context.Update(supply);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to edit supply", ex);
            }
        }
    }
}
