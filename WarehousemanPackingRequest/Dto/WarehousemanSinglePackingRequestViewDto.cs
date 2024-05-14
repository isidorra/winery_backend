namespace winery_backend.WarehousemanPackingRequest.Dto
{
    public class WarehousemanSinglePackingRequestViewDto
    {
        public int PackingRequestId { get; set; }
        public DateTime PackingRequestCreationDate { get; set; }
        public List<ProductWarehousemanDto> ProductWarehousemanDtos { get; set; }

        public WarehousemanSinglePackingRequestViewDto()
        {
            
        }

        public WarehousemanSinglePackingRequestViewDto(int packingRequestId, DateTime packingRequestCreationDate, List<ProductWarehousemanDto> productWarehousemanDtos)
        {
            PackingRequestId = packingRequestId;
            PackingRequestCreationDate = packingRequestCreationDate;
            ProductWarehousemanDtos = productWarehousemanDtos;
        }
    }
}
