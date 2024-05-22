using Supplies;
using System.Numerics;

namespace winery_backend.Grapes
{
    public class Grape
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Type { get; set; } //1 red, 0 white
        public bool IsRipe { get; set; }
        public int Quality { get; set; }
        public DateTime PlantingDate { get; set; }
        public int? FertilizerId { get; set; }
        public virtual Supply? Fertilizer { get; set; }
        public int? PesticideId { get; set; }
        public virtual Supply? Pesticide { get; set; }
        public double HarvestedAmount { get; set; }

        public Grape() { }

        public Grape(int id, string name, bool type, bool isRipe, int quality, DateTime plantingDate, double harvestedAmount)
        {
            Id = id;
            Name = name;
            Type = type;
            IsRipe = isRipe;
            Quality = quality;
            PlantingDate = plantingDate;
            HarvestedAmount = harvestedAmount;
        }

        public Grape(int id, string name, bool type, bool isRipe, int quality, DateTime plantingDate, int fertilizerId, int pesticideId, double harvestedAmount)
        {
            Id = id;
            Name = name;
            Type = type;
            IsRipe = isRipe;
            Quality = quality;
            PlantingDate = plantingDate;
            FertilizerId = fertilizerId;
            PesticideId = pesticideId;
            HarvestedAmount = harvestedAmount;
        }

    }
}
