using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week2_Homework2.Data.Context;


namespace HTask9
{
    public class BestBook : BookDetail
    {
        public BestBook(DatabaseContext databaseContext) :base(databaseContext)
        {
            
        }
        public List<BookItem> GetList()
        {
            return MovieItemList.Where(x => x.BookScore > 8).OrderBy(o => o.BookScore).ToList();
        }
    }
}