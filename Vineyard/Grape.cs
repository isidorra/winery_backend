using System.Numerics;

namespace winery_backend.Vineyard
{
    public class Grape
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; } //1 red, 0 white
        public bool IsRipe { get; set; }
        public int Quality { get; set; }
        public DateTime PlantingDate { get; set; }

        public Grape(int id, string name, bool type, bool isRipe, int quality, DateTime plantingDate)
        {
            Id = id;
            Name = name;
            Type = type;
            IsRipe = isRipe;
            Quality = quality;
            PlantingDate = plantingDate;
        }
    }
}
