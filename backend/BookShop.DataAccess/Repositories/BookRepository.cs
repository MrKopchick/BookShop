using BookShop.Core.Models;
using Microsoft.EntityFrameworkCore;
using BookShop.DataAccess.Entities;

namespace BookShop.DataAccess.Repositories
{
    public class BookRepository
    {
        private readonly BookStoreDBContext _context;
        public BookRepository(BookStoreDBContext context) 
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var bookEntities = await _context.Books.AsNoTracking().ToListAsync();
            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Price).Book)
                .ToList();
            
            return books;
        }

        public async Task<Guid> CreateBookAsync(Book book)
        {
            var bookEntity = new BookEntity { Id = book.Id, Title = book.Title, Price = book.Price };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> UpdateBookAsync(Guid id, string title, string description, decimal price)
        {
            await _context.Books.Where(b => b.Id == id).ExecuteUpdateAsync(s => s
                                                                .SetProperty(b => b.Title, b => title)
                                                                .SetProperty(b => b.Description, b => description)
                                                                .SetProperty(b => b.Price, b=> price));

            return id;
        }

        public async Task<Guid> DeleteBookAsync(Guid id)
        {
            await _context.Books.Where(b=>b.Id == id).ExecuteDeleteAsync();

            return id;
        }
    }
}
