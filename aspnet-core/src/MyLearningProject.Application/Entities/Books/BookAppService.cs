using Abp.Application.Services;
using Abp.Domain.Repositories;
using MyLearningProject.Entities.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLearningProject.Entities.Books
{
    public class BookAppService : ApplicationService
    {
        private readonly IRepository<Book, int> _bookrepository;

        public BookAppService(IRepository<Book, int> bookrepository)
        {
            _bookrepository = bookrepository;
        }
        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await _bookrepository.GetAllListAsync();
            return ObjectMapper.Map<List<BookDto>>(books);
        }
        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await _bookrepository.GetAsync(id);
            return ObjectMapper.Map<BookDto>(book);
        }
        public async Task<BookDto> CreateAsync(BookDto input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var book = new Book
            {
                Title = input.Title,
                Author = input.Author
            };

            // Insert the new Book entity into the database
            var bookEntity = await _bookrepository.InsertAsync(book);

            await CurrentUnitOfWork.SaveChangesAsync(); // Ensure the changes are saved

            // Map the entity to a DTO to return to the client
            var bookDto = ObjectMapper.Map<BookDto>(bookEntity);

            return bookDto;
        }
        public async Task<BookDto> UpdateAsync(int id, BookDto input)
        {
            var book = await _bookrepository.GetAsync(id);
            book.Title = input.Title;
            book.Author = input.Author;
            var updatedBook = await _bookrepository.UpdateAsync(book);
            return ObjectMapper.Map<BookDto>(updatedBook);
        }
        public async Task DeleteAsync(int id)
        {
            await _bookrepository.DeleteAsync(id);
        }
    }
}
