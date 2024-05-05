using System.ComponentModel;

namespace winery_backend.Vineyard
{
    public class Parcel
    {
        public int Id { get; set; }
        public Grape Grape { get; set; }
        public long Amount { get; set; } //in kg
        public long Size { get; set; } //in ha

        public Parcel(int id, Grape grape, long amount, long size)
        {
            Id = id;
            Grape = grape;
            Amount = amount;
            Size = size;
        }

        public long RecommendedWateringAmount()
        {
            if(DateTime.Now.Month >= 4 && DateTime.Now.Month <= 9) // it is summer
            {
                if (Grape.PlantingDate.AddYears(3) > DateTime.Now) //young grape 
                {
                    return this.Size * 800;
                }
                else //old grape
                {
                    return this.Size * 500;
                }
            }
            else //it is winter
            {
                if (Grape.PlantingDate.AddYears(3) > DateTime.Now) //young grape 
                {
                    return this.Size * 500;
                }
                else //old grape
                {
                    return this.Size * 300;
                }
            }
            
        }
    }
}
