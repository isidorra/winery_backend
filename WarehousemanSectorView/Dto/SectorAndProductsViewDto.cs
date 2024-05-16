using winery_backend.LogisticianViewCustomerOrder.Dto;

namespace winery_backend.WarehousemanSectorView.Dto
{
    public class SectorAndProductsViewDto
    {
        public string SectorName { get; set; }
        public string SectorImage { get; set; }
        public List<ProductWarehousemanInSectorDto> productWarehousemanInSectorDtos { get; set; }

        public SectorAndProductsViewDto()
        {

        }

        public SectorAndProductsViewDto(string sectorName, string sectorImage, List<ProductWarehousemanInSectorDto> productWarehousemanInSectorDtos)
        {
            SectorName = sectorName;
            SectorImage = sectorImage;
            this.productWarehousemanInSectorDtos = productWarehousemanInSectorDtos;
        }
    }
}
