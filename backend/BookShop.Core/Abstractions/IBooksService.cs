using BookShop.Core.Models;

namespace BookShop.Core.Abstractions
{
    public interface IBooksService
    {
        Task<Guid> CreateBookAsync(Book book);
        Task<Guid> DeleteBookAsync(Guid id);
        Task<List<Book>> GetAllBooksAsync();    
        Task<Guid> UpdateBookAsync(Guid id, string title, string description, decimal price);
    }
}
