using Microsoft.EntityFrameworkCore;

namespace BookShop.DataAccess
{
    public class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options) : base(options) 
        {
            
        }
    }
}