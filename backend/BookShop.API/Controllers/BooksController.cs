using BookShop.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using BookShop.API.Contracts;
using BookShop.Core.Models;

namespace BookShop.API.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService) {
            _booksService = booksService;
        }

        [HttpGet]   
        public async Task<ActionResult<List<BooksResponse>>> GetBookAsync()
        {
            var books = await _booksService.GetAllBooksAsync();
            
            var response = books.Select(book => new BooksResponse(book.Id, book.Title, book.Description, book.Price)); 

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BooksResponse>> CreateBookAsync([FromBody] BooksRequest request){
            var (book, error) = Book.Create(Guid.NewGuid(), request.Title, request.Description, request.Price);

            if(!string.IsNullOrEmpty(error)){
                return BadRequest(error);
            }

            return Ok(book);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateBookAsync(Guid id, [FromBody] BooksRequest request){
            var bookId = await _booksService.UpdateBookAsync(id, request.Title, request.Description, request.Price);

            return Ok(bookId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBookAsync(Guid id){
            return Ok(await _booksService.DeleteBookAsync(id));
        }   
    }        
}
