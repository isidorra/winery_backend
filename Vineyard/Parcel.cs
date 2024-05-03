namespace winery_backend.Vineyard
{
    public class Parcel
    {
        public int Id { get; set; }
        public Grape Grape { get; set; }
        public long Amount { get; set; } //in kg

        public Parcel(int id, Grape grape, long amount)
        {
            Id = id;
            Grape = grape;
            Amount = amount;
        }
    }
}
