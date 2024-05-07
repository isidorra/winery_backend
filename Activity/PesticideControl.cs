namespace winery_backend.Activity
{
    public class PesticideControl : Activity
    {
        public long Amount { get; set; }
        public int PesticideId { get; set; }
        public Supply Pesticide { get; set; }

        public PesticideControl()
        {
        }

        public PesticideControl(DateTime startDate, int parcelId, long amount, int pesticideId) : base(Guid.NewGuid(), startDate, startDate.AddDays(1), false, ActivityType.Fertilization, parcelId)
        {
            Amount = amount;
            PesticideId = pesticideId;
        }
    }
}
