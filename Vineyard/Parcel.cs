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

        public long RecommendedFertilizerAmount()
        {
            long coef = 1;

            if (Grape.PlantingDate.AddYears(3) > DateTime.Now) //young grape 
            {
                coef = (long)0.7; //younger grapes need less fertilizer
            }

            return 10000*this.Size*(1/Grape.Quality)*coef; //10 000kg per ha, inverse proportional to the quality of grapes and having in mind the age of the grape
        }

        public long RecommendedPesticideAmount()
        {
            long coef = 1;

            if (Grape.PlantingDate.AddYears(3) > DateTime.Now) //young grape 
            {
                coef = (long)0.7; //younger grapes need less pesticide
            }

            return 1 * this.Size * (1 / Grape.Quality) * coef; //1kg per ha, inverse proportional to the quality of grapes and having in mind the age of the grape
        }
    }
}
