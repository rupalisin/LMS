using DataAccessLayer.BookRepository;
using DataAccessLayer.BorrowBookRepository;

using DataObjectLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library_Backend.Controllers
{
    [Route("api/[controller]")]
    public class BorrowBookController : ControllerBase
    {
        private readonly IBorrowBook _borrowBook;
        public BorrowBookController(IBorrowBook borrowBook)
        {
            _borrowBook = borrowBook;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook([FromBody] BorrowRequestModel requestModel )
        {
            try
            {
                 
             await _borrowBook.BorrowBookAsync(requestModel.Id, requestModel.bookId);
                return Ok("Book borrowed successfully");
            }
            catch(ValidationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
