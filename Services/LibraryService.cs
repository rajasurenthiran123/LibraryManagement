using LBMS_V1.Models;
using LBMS_V1.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LBMS_V1.Services
{
    public class LibraryService : ILibrary
    {
        private readonly LibraryContext _context;

        public LibraryService(LibraryContext context)
        {
            _context = context;
        }

        public async Task CreateBookAsync(CreateBookDTO bookDto)
        {
            var book = new Books
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                PublishedYear = bookDto.PublishedYear
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateBookAsync(int id, CreateBookDTO bookDto)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            book.Title = bookDto.Title;
            book.Author = bookDto.Author;
            book.PublishedYear = bookDto.PublishedYear;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

    }
}
