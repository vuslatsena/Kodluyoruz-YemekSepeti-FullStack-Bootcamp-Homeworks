using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HTask9.Data.Entity;

namespace HTask9
{
    public class DBContext : DBContext
    {
        public DatabaseContext(DBContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookType> BookType { get; set; }
        public DbSet<BookTypeRelation> BookTypeRelation { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                UserName = "Vuslat",
                IsAdmin = true
            });

            modelBuilder.Entity<BookType>().HasData(new BookType
            {
                BookTypeId = 1,
                Name = "Comics"

            });

            modelBuilder.Entity<BookType>().HasData(new MovieType
            {
                BookTypeId = 2,
                Name = "Roman"
            });
        }
    }
}