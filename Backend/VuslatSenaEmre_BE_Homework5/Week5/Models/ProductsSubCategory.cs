using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.Models
{
    public class ProductsSubCategory
    {
        public int ProductSubCategoryID { get; set; }
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
    }
}
