using AvaloniaApp.Access;
using AvaloniaApp.Model;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp.Service
{
    internal class BookService
    {
        private IAppDbContext _appDbContext;

        public BookService(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _appDbContext.Books;
        }

        public async Task<Book> CreateBook(string name, string author, string category)
        {
            var newBook = new Book()
            {
                Name = name,
                Author = author,
                Category = category
            };

            var result = _appDbContext.Books.Add(newBook);
            await _appDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<bool> RemoveBook(int id)
        {
            var noteToRemove = _appDbContext.Books.First(n => n.Id == id);
            var result = _appDbContext.Books.Remove(noteToRemove);
            await _appDbContext.SaveChangesAsync();
            return result != null;
        }



    }
}

