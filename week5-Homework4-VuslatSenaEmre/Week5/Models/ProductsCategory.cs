using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5.Models
{
    public class ProductsCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public virtual List<ProductsSubCategory> ProductSubcategories { get; set; }
    }
}
