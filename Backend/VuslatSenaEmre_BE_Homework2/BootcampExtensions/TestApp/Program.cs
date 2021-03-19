using BootcampExtensions.Model;
using System.Collections.Generic;
namespace BootcampExtensions.TestApp
{
    class Program
    {
        List<Library> LateFeeList = new List<Library>()
            {
                 new Library{ BookId = 1, AuthorName = "Ahmet Ümit", BarrowerName = "Vuslat", LateDateCount = 4, LateFee = 5 ,TotalFee= 20},
                 new Library{ BookId = 2, AuthorName = "Dan Brown", BarrowerName = "Sena", LateDateCount = 4, LateFee = 5 ,TotalFee= 20}
            };

        LateFeeList.ApplyLateFee();

    }
}
