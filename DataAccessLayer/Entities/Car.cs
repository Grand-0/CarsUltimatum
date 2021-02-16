using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int YearCreate { get; set; }
        public int Count { get; set; }

        public string FuelType { get; set; }
        public int VolumeEngene { get; set; }
        public int CountHourseForce { get; set; }
        
        public int FullWeight { get; set; }
        public int FuelVolume { get; set; }

        public string Color { get; set; }
        public int CountPlaces { get; set; }
        public string Transmission { get; set; }

        public string CarClassName { get; set; }
        public string CompanyName { get; set; }
    }
}
