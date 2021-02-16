using System.Collections.Generic;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }

        public int CustomerID { get; set; }
    }
}
