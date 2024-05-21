namespace winery_backend.Vineyard
{
    public class HarvestedGrape
    {
        public int Id { get; set; }
        public int GrapeId { get; set; }
        public virtual Grape? Grape { get; set; }

        public HarvestedGrape()
        {
        }
    }
}
