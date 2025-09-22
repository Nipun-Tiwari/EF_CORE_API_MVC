using EF_CORE_EMPTY_CONTROLLER.Models;
using EF_CORE_EMPTY_CONTROLLER.Interface;
using Microsoft.EntityFrameworkCore;

namespace EF_CORE_EMPTY_CONTROLLER.Repository
{
    public class AuthorRepository : IBookAuthor<Author>
    {
        private readonly BookAuthorContext _context;

        public AuthorRepository(BookAuthorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetById(int id)
        {
            return await _context.Authors
                .FirstOrDefaultAsync(a => a.AuthId == id);
        }

      

        public async Task Add(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Author newauth)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthId == id);
            if (author != null)
            {
                author.AuthName = newauth.AuthName;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.AuthId == id);
            if (author != null)
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.AuthId == id);
                if (book != null)
                {
                    _context.Books.Remove(book);
                }
                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
        }
    }
}
