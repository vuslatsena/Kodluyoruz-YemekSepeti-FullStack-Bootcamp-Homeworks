using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.Models
{
    public class Products
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public virtual List<ProductsCost> ProductCosts { get; set; }
    }
}
