using winery_backend.Grapes;

namespace winery_backend.WineProduction.Pressings
{
    public class Pressing
    {
        public Guid Id { get; set; }
        public int GrapeId { get; set; }
        public virtual Grape Grape { get; set; }
        public double Amount { get; set; } //in litres
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PressingType PressingType { get; set; }

        public Pressing()
        {
        }

        public Pressing(Guid id, int grapeId, Grape grape, double amount, DateTime startDate, DateTime endDate, PressingType pressingType)
        {
            Id = id;
            GrapeId = grapeId;
            Grape = grape;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            PressingType = pressingType;
        }

        public Pressing(int grapeId, double amount, DateTime startDate, DateTime endDate, PressingType pressingType)
        {
            Id = Guid.NewGuid();
            GrapeId = grapeId;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            PressingType = pressingType;
        }
    }
}
