namespace winery_backend.GrapeQualityReport.Interface
{
    public interface IGrapeQualityReportService
    {
        ICollection<GrapeQualityReport> GetAll();
        GrapeQualityReport GetById(int id);
        ICollection<GrapeQualityReport> GetByGrapeId(int id);
    }
}
