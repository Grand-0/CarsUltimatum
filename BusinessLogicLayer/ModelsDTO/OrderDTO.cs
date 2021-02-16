using System.Collections.Generic;

namespace BusinessLogicLayer.ModelsDTO
{
    public class OrderDTO
    {
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }

        public List<CarDTO> Cars { get; set; }
        public int CustomerId { get; set; }
    }
}
