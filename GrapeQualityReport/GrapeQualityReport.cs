using Supplies;
using winery_backend.Grapes;

namespace winery_backend.GrapeQualityReport
{
    public class GrapeQualityReport
    {
        public int Id { get; set; }
        public int GrapeId { get; set; }
        public virtual Grape Grape { get; set; }
        public double OldQuality { get; set; }
        public double NewQuality { get; set; }
        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }
        public double Amount { get; set; }

        public GrapeQualityReport()
        {

        }

        public GrapeQualityReport(int id, int grapeId, double oldQuality, double newQuality, double amount)
        {
            Id = id;
            GrapeId = grapeId;
            OldQuality = oldQuality;
            NewQuality = newQuality;
            Amount = amount;
            Supply = null;
            SupplyId = 0;
        }
    }
}
