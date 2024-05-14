namespace winery_backend.WarehousemanSectorView.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using winery_backend.ViewWarehouse.Interface;

    [Route("api/warehouseman/sectorView")]
    [ApiController]
    public class WarehousemanSectorViewController : Controller
    {
        private readonly ISectorService _sectorService;

        public WarehousemanSectorViewController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }
    }
}
