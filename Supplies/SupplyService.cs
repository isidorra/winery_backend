using winery_backend.Supplies.Interface;

﻿using Supplies;

namespace winery_backend.Invetory
{
    public class SupplyService : ISupplyService
    {
        private readonly ISupplyRepository _supplyRepository;

        public SupplyService(ISupplyRepository supplyRepository)
        {
            _supplyRepository = supplyRepository;
        }

        public ICollection<Supply> GetAll()
        {
           return _supplyRepository.GetAll();
        }

        public Supply GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Supply> GetBySupplyType(SupplyType type)
        {
            return _supplyRepository.GetBySupplyType(type);
        }
    }
}
