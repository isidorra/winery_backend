﻿using Microsoft.EntityFrameworkCore;
using Supplies;
using winery_backend.Machines.Interface;

namespace winery_backend.Machines
{
    public class MachineRepository : IMachineRepository
    {
        private readonly DataContext _context;

        public MachineRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Machine> GetAll()
        {
            return _context.Machines.OrderBy(s => s.Id).ToList();
        }

        public Machine GetById(int id)
        {
            return _context.Machines.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public Machine GetByName(string name)
        {
            return _context.Machines.Where(s => s.Name.Equals(name)).FirstOrDefault();
        }
    }
}
