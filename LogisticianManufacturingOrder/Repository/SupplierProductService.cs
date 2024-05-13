﻿using winery_backend.LogisticianManufacturingOrder.Interface;

namespace winery_backend.LogisticianManufacturingOrder.Repository
{
    public class SupplierProductService : ISupplierProductService
    {
        private readonly ISupplierProductRepository _supplierProductRepository;
        public SupplierProductService(ISupplierProductRepository supplierProductRepository)
        {
            _supplierProductRepository = supplierProductRepository;
        }
    }
}
