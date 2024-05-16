
namespace winery_backend.Activity
{
    public class Fertilization : Activity
    {
        public long Amount { get; set; }
        public int FertilizerId { get; set; }
        public Supply.Supply Fertilizer { get; set; }

        public Fertilization()
        {
        }

        public Fertilization(DateTime startDate, int parcelId, long amount, int fertilizerId) : base(Guid.NewGuid(), startDate, startDate.AddDays(1), false, ActivityType.Fertilization, parcelId)
        {
            Amount = amount;
            FertilizerId = fertilizerId;
        }
    }
}
