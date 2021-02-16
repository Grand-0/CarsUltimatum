using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Image
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public int CarID { get; set; }
    }
}
