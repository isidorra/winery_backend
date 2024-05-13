namespace winery_backend.ViewWarehouse.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.LogisticianViewCustomerOrder.Interface;
    using winery_backend.LogisticianViewCustomerOrder.Models;
    using winery_backend.ViewWarehouse.Dto;
    using winery_backend.ViewWarehouse.Interface;
    using winery_backend.ViewWarehouse.Models;
    using winery_backend.ViewWarehouse.Service;

    [Route("api/logistician/sectors")]
    [ApiController]
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;
        private readonly IProductService _productService;
        public SectorController(ISectorService sectorService, IProductService productService)
        {
            _sectorService = sectorService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetInformationAllSectors(string sectorName, string warehousemanName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Sector sector = _sectorService.FindSectorBySectorName(sectorName);

            List<Product> products = _productService.FindProductsBySectorId(sector.SectorId);

            List<ProductLogisticianInSectorDto> productLogisticianInSectorDtos = new List<ProductLogisticianInSectorDto>();

            foreach(Product product in products)
            {
                productLogisticianInSectorDtos.Add(new ProductLogisticianInSectorDto(product.ProductName, product.ProductQuantity));
            }

            SectorViewDto sectorViewDto = new SectorViewDto(sector.SectorName, sector.SectorImage, warehousemanName, productLogisticianInSectorDtos);

            return Ok(sectorViewDto);
        }
    }
}
