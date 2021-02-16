using System.Collections.Generic;

namespace WebApi.Models
{
    public class Order
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }

        public int CustomerId { get; set; }
        public List<Car> Cars { get; set; }
    }
}
