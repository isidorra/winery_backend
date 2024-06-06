using winery_backend.GrapeQualityReport.Interface;

namespace winery_backend.GrapeQualityReport
{
    public class GrapeQualityReportService : IGrapeQualityReportService
    {

        private readonly IGrapeQualityReportRepository _grapeQualityReportRepository;

        public GrapeQualityReportService(IGrapeQualityReportRepository grapeQualityReportRepository)
        {
            _grapeQualityReportRepository = grapeQualityReportRepository;
        }

        public ICollection<GrapeQualityReport> GetAll()
        {
            return _grapeQualityReportRepository.GetAll();
        }

        public ICollection<GrapeQualityReport> GetByGrapeId(int id)
        {
            return _grapeQualityReportRepository.GetByGrapeId(id);
        }

        public GrapeQualityReport GetById(int id)
        {
            return _grapeQualityReportRepository.GetById(id);
        }
    }
}
