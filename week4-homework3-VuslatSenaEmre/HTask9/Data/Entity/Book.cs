using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HTask9.Enums;

namespace HTask9
{// base film sınıfı 
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public decimal BookScore { get; set; }
        public BookStatus BookStatus { get; set; }
        public Page BookPage { get; set; }
        public int UserId { get; set; }
    }
}