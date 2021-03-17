using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HTask9.Data.Context;
using HTask9.Data.Entity;
using HTask9.Mapping;

namespace Week2_Homework2.Business
{
    public class BookDetail
    {
        public List<BookItem> BookItemList { get; set; }
        
        public BookDetail(DatabaseContext databaseContext)
        {
            BookItemList = new List<MovieItem>();
            var movieList = databaseContext.Movie.ToList();
            foreach (var movie in movieList)
            {
                MovieItem BookItem = BooktoBookItem.Convert(book);
                var BookTypeRelationList = databaseContext.BookTypeRelation.Where(x => x.BookId == bookBookId).ToList();
                foreach (var BookTypeRelationItem in BookTypeRelationList)
                {
                    varBookType = databaseContext.BookType.FirstOrDefault(x => x.BookTypeId == BookTypeRelationItem.BookTypeId);
                    BookItem.BookTypeList.Add(BookType);
                }
                BookItemList.Add(BookItem);
            }
        }

    }

    public class BookItem 
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookScore { get; set; }
        public List<BookType> BookTypeList { get; set; }
        public Page ReleasedDate { get; set; }
    }
}