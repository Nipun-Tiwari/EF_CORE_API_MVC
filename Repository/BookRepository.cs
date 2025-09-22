using EF_CORE_EMPTY_CONTROLLER.Models;
using EF_CORE_EMPTY_CONTROLLER.Interface;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
namespace EF_CORE_EMPTY_CONTROLLER.Repository
{
    public class BookRepository: IBookAuthor<Book>
    {
        private readonly BookAuthorContext _context;

        public BookRepository(BookAuthorContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Books
                .FirstOrDefaultAsync(b => b.BookId == id);
        }
        public async Task Add(Book book)
        {
                       _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
       
        public async Task Update(int id, Book newBook)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (book!=null)
            {
                book.Title = newBook.Title;
                book.AuthId = newBook.AuthId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.BookId == id);
            if (book != null)
            {
                _context.Remove(book);
                await _context.SaveChangesAsync();
            }
        }




    }
}
