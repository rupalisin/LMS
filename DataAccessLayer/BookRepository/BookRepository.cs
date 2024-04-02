using DataObjectLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _BookContext;
        public BookRepository(LibraryDbContext BookContext)
        {
            _BookContext = BookContext;
        }
        public async void Add(Book book)
        {
            await _BookContext.Books.AddAsync(book);
        }

        public void Delete(Book book)
        {
            _BookContext.Books.Remove(book);
        }

         public async Task <List<Book>> GetAllBooks()
        {
            return await _BookContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _BookContext.Books.FirstOrDefaultAsync(x => x.bookId == id);
        }

         public void SaveChanges()
        {
            _BookContext.SaveChanges();
        }

         public void Update(int id, Book book)
        {
            Book UpdateBook = _BookContext.Books.FirstOrDefault(x => x.bookId == id);

            //UpdateBook.Book_Name = book.Book_Name;
            //UpdateBook.Author_Name = book.Author_Name;
            //UpdateBook.Description = book.Description;
            //UpdateBook.genre = book.genre;
            //UpdateBook.Rating = book.Rating;
            
            UpdateBook.Is_Book_Available = book.Is_Book_Available;
            UpdateBook.Lent_By_User_id = book.Lent_By_User_id;
            UpdateBook.Currently_Borrowed_By_User_Id = book.Currently_Borrowed_By_User_Id;
            _BookContext.SaveChanges();
        }

        
    }
}
