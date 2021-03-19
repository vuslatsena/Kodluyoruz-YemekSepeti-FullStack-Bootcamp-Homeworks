using System;
using System.Collections.Generic;
using System.Text;

namespace BootcampExtensions.Model
{
    class LibraryDTO
    {
        public int BookId { get; set; }
        public string AuthorName { get; set; }
        public string BarrowerName { get; set; }
        public decimal LateFee { get; set; }
        public decimal LateDateCount { get; set; }
        public decimal TotalFee { get; set; }
    }
}
