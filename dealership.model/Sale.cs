using System;
using System.Collections.Generic;
using System.Text;

namespace dealership.model
{
    public class Sale : BaseModel
    {
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public Vehicle Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime? Date { get; set; }
    }
}
