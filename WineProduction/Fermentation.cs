using winery_backend.Grapes;

namespace winery_backend.WineProduction
{
    public class Fermentation
    {
        public Guid Id { get; set; }
        public int GrapeId { get; set; }
        public virtual Grape Grape { get; set; }
        public double Amount { get; set; } //in litres
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Yeast { get; set; }
        public double Sugar { get; set; }
        public double Temperature { get; set; }
        public double PhValue { get; set; }

        public Fermentation()
        {
        }

        public Fermentation(Guid id, int grapeId, Grape grape, double amount, DateTime startDate, DateTime endDate)
        {
            Id = id;
            GrapeId = grapeId;
            Grape = grape;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            Yeast = 0;
            Sugar = 0;
            Temperature = 0;
            PhValue = 0;
        }

        public Fermentation(Guid id, int grapeId, double amount, DateTime startDate, DateTime endDate, double yeast, double sugar, double temperature, double phValue)
        {
            Id = id;
            GrapeId = grapeId;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            Yeast = yeast;
            Sugar = sugar;
            Temperature = temperature;
            PhValue = phValue;
        }

        public Fermentation(int grapeId, double amount, DateTime startDate, DateTime endDate, double yeast, double sugar, double temperature, double phValue)
        {
            Id = Guid.NewGuid();
            GrapeId = grapeId;
            Amount = amount;
            StartDate = startDate;
            EndDate = endDate;
            Yeast = yeast;
            Sugar = sugar;
            Temperature = temperature;
            PhValue = phValue;
        }
    }
}
