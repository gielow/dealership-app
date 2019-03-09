using System;

namespace dealership.model
{
    public class Vehicle : BaseModel
    {
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
