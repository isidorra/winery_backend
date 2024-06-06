using winery_backend.Grapes;

namespace winery_backend.GrapeQualityReport.Interface
{
    public interface IGrapeQualityReportRepository
    {
        ICollection<GrapeQualityReport> GetAll();
        GrapeQualityReport GetById(int id);
        ICollection<GrapeQualityReport> GetByGrapeId(int id);

    }
}
