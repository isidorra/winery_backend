﻿using winery_backend.Invetory.Interface;

namespace winery_backend.Invetory
{
    public class SupplyRepository : ISupplyRepository
    {
        private readonly DataContext _context;

        public SupplyRepository(DataContext context)
        {
            _context = context;
        }

        public bool Create(Supply.Supply supply)
        {
            _context.Add(supply);
            return Save();
        }

        public ICollection<Supply.Supply> GetAll()
        {
            return _context.Supplies.OrderBy(s => s.Id).ToList();
        }

        public Supply.Supply GetById(int id)
        {
            return _context.Supplies.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public Supply.Supply GetByName(string name)
        {
            return _context.Supplies.Where(s => s.Name.Equals(name)).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public void Update(Supply.Supply supply)
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
