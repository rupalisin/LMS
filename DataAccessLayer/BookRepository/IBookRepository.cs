using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BookRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int bookId);
        void Add(Book book);
        void Update(int bookId, Book book);
        void Delete(Book book);
        void SaveChanges();
        
    }
}
