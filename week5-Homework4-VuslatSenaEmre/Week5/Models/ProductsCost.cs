using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.Models
{
    public class ProductsCost
    {
        public int ProductID { get; set; }
        public decimal StandardCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
