using BookShop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) 
        {
            
        }


        public DbSet<BookEntity> Books { get; set; }
    }
}