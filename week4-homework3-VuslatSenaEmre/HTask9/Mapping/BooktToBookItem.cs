using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HTask9.Business;
using HTask9.Data.Entity;


namespace HTask9.Mapping
{
    public static class BookToBookItem
    {
        public static BookItem Convert(Book Book )
        {
            BookItem BookItem = new BookItem();
           BookItem.BookId = Book.BookId;
            Booktem.BookName = Book.BookName;
           BookItem.BookScore = Book.BookScore;
            BookItem.BookTypeList = new List<BookType>();
            return BookItem;
        }
    }
}