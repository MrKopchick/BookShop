using BookShop.Core.Abstractions;
using BookShop.Core.Abstractons;
using BookShop.Core.Models;
using BookShop.DataAccess.Repositories;

namespace BookShop.Application.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBookRepository _booksRepository;
        public BooksService(IBookRepository bookRepository)
        {
            _booksRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _booksRepository.GetBooksAsync();
        }

        public async Task<Guid> CreateBookAsync(Book book)
        {
            return await _booksRepository.CreateBookAsync(book);
        }

        public async Task<Guid> UpdateBookAsync(Guid id, string title, string description, decimal price)
        {
            return await _booksRepository.UpdateBookAsync(id, title, description, price);
        }

        public async Task<Guid> DeleteBookAsync(Guid id)
        {
            return await _booksRepository.DeleteBookAsync(id);
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            return await _booksRepository.GetBooksAsync();
        }
    }
}
