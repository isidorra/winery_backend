namespace winery_backend.ViewWarehouse.Interface
{
    public interface ISectorService
    {
        List<string> FindSectorsName(List<int> requiredSectorIds);
        int FindSectorId(string sectorName);
        string FindSectorName(int sectorId);
    }
}
