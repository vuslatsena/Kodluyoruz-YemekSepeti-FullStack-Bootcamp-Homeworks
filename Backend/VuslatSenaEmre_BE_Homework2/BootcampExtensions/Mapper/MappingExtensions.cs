using System;
using System.Collections.Generic;
using System.Text;
using BootcampExtensions.Model;
using System.Linq;


namespace BootcampExtensions.Mapper
{
    public static class MappingExtensions
    {
        public static List<Library> .... (this List<LibraryDTO> data)
        {
            return data.Select(p => new Library
            {
                BookId = p.BookId,
                AuthorName = p.AuthorName,
                BarrowerName = p.BarrowerName,
                LateFee = p.LateFee,
            }).ToList();
        }

        public static List<LibraryDTO> ...... (this List<Library> data)
        {
            List<LibraryDTO> resultItems = new List<LibraryDTO>();
            foreach (var item in data)
            {
                resultItems.Add(new LibraryDTO
                {
                    BookId = item.BookId,
                    AuthorName = item.AuthorName,
                    BarrowerName = item.BarrowerName,
                    TotalLateFee = item.TotalLateFee
                });
            }
            return resultItems;
        }
    }
}
