using BookShop.Core.Models;

namespace BookShop.Core.Abstractons{
    public interface IBookRepository{
        Task<Guid> CreateBookAsync(Book book);
        Task<Guid> DeleteBookAsync(Guid id);
        Task<List<Book>> GetBooksAsync();
        Task<Guid> UpdateBookAsync(Guid id, string title, string description, decimal price);
    }
}