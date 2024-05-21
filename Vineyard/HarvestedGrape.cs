namespace winery_backend.Vineyard
{
    public class HarvestedGrape
    {
        public int Id { get; set; }
        public int GrapeId { get; set; }
        public Grape? Grape { get; set; }
    }
}
