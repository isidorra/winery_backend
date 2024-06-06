using System.Collections.ObjectModel;
using winery_backend.GrapeQualityReport.Interface;
using winery_backend.Vineyard;

namespace winery_backend.GrapeQualityReport
{
    public class GrapeQualityReportRepository : IGrapeQualityReportRepository
    {
        private readonly DataContext _context;

        public GrapeQualityReportRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<GrapeQualityReport> GetAll()
        {
            return _context.GrapeQualityReports.OrderBy(g => g.Id).ToList();

        }

        public ICollection<GrapeQualityReport> GetByGrapeId(int id)
        {
            ICollection<GrapeQualityReport> allReports = GetAll();
            ICollection<GrapeQualityReport> fillteredReports = new Collection<GrapeQualityReport>();

            foreach (GrapeQualityReport report in allReports)
            {
                if (report.Grape.Id == id)
                    fillteredReports.Add(report);
            }

            return fillteredReports;
        }

        public GrapeQualityReport GetById(int id)
        {
            return _context.GrapeQualityReports.Where(g => g.Id.Equals(id)).FirstOrDefault();
        }
    }
}
