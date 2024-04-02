using DataAccessLayer.BookRepository;
using DataAccessLayer.UserRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BorrowBookRepository
{
    public class BorrowBook:IBorrowBook
    {
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;

        public BorrowBook(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public async Task BorrowBookAsync(int Id,int bookId)
        {
            var book = await _bookRepository.GetBookById(bookId);
            var user = await _userRepository.GetUserById(Id);

            if (!book.Is_Book_Available)
            {
                throw new ValidationException("Book has already borrowed");
            }
            if (user.Tokens_Available <= 0)
            {
                throw new ValidationException("You have no tokens left");
            }

             if (book.Lent_By_User_id==user.Id)
            {
              throw new ValidationException("You can not borrow your own book");
            }
            book.Is_Book_Available = false;
            book.Currently_Borrowed_By_User_Id = Id;
            user.Tokens_Available--;

            var lenderId = book.Lent_By_User_id;
            var lender = await _userRepository.GetUserById(lenderId);
            lender.Tokens_Available++;
            await _userRepository.UpdateUser(Id, user.Tokens_Available);
            await _userRepository.UpdateUser(lenderId, lender.Tokens_Available);
             _bookRepository.Update(bookId, book);


        }

    }
}
