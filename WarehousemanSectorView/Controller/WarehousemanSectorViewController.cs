namespace winery_backend.WarehousemanSectorView.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.ViewWarehouse.Dto;
    using winery_backend.ViewWarehouse.Interface;
    using winery_backend.ViewWarehouse.Models;
    using winery_backend.ViewWarehouse.Service;
    using winery_backend.WarehousemanSectorView.Dto;

    [Route("api/warehouseman/sectorView")]
    [ApiController]
    public class WarehousemanSectorViewController : Controller
    {
        private readonly ISectorService _sectorService;
        private readonly IProductService _productService;
        private readonly IPricingService _pricingService;
        private readonly IProductCategoryService _productCategoryService;

        public WarehousemanSectorViewController(ISectorService sectorService, IProductService product, IPricingService pricingService, IProductCategoryService productCategoryService)
        {
            _sectorService = sectorService;
            _productService = product;
            _pricingService = pricingService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult GetInformationAllProducts(int warehousemanId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Sector sector = _sectorService.FindByWarehousemanId(warehousemanId);

            List<Product> products = _productService.FindProductsBySectorId(sector.SectorId);

            List<ProductWarehousemanInSectorDto> productWarehousemanInSectorDtos = new List<ProductWarehousemanInSectorDto>();

            foreach(Product product in products)
            {
                productWarehousemanInSectorDtos.Add(new ProductWarehousemanInSectorDto(product.Name, product.Quantity));
            }

            SectorAndProductsViewDto sectorAndProductsViewDto = new SectorAndProductsViewDto(sector.SectorName, sector.SectorImage, productWarehousemanInSectorDtos);

            return Ok(sectorAndProductsViewDto);
        }

        [HttpGet("singleProduct")]
        public IActionResult GetInformationSingleProduct(string productName)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product product = _productService.FindProductByProductName(productName);

            double? productPrice = _pricingService.FindById(product.PricingId);

            string productCategoryName = _productCategoryService.FindById(product.ProductCategoryId);

            SingleProductSectorDto singleProductSectorDto = new SingleProductSectorDto(productName, productCategoryName, product.PackagingSize, productPrice, product.AlcoholPercentage, product.Photo);

            return Ok(singleProductSectorDto);
        }
    }
}
