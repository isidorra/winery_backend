namespace winery_backend.ViewWarehouse.Interface
{
    public interface ISectorRepository
    {
        string FindSectorName(int sectorId);
        int FindSectorId(string sectorName);
    }
}
