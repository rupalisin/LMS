using DataAccessLayer.BookRepository;
using DataObjectLayer;
using Microsoft.AspNetCore.Mvc;

namespace Library_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController:ControllerBase
    {
        private readonly IBookRepository _BookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            var books = _BookRepository.GetAllBooks().Result;
            return Ok(books);
        }
        [HttpPost]
        public ActionResult AddBook([FromBody] Book book)
        {
            _BookRepository.Add(book);
            _BookRepository.SaveChanges();
            return Ok(book);
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetBook([FromRoute] int id)
        {
            Book book = _BookRepository.GetBookById(id).Result;
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult UpdateBook([FromRoute] int id, [FromBody] Book book)
        {
            Book updateBook = _BookRepository.GetBookById(id).Result;
            if (updateBook == null)
            {
                return NotFound();
            }
            else
            {
                _BookRepository.Update(id, book);
                _BookRepository.SaveChanges();
                return Ok(updateBook);
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {
            Book deleteBook = _BookRepository.GetBookById(id).Result;
            if (deleteBook == null)
            {
                return NotFound();
            }
            else
            {
                _BookRepository.Delete(deleteBook);
                _BookRepository.SaveChanges();
                return Ok(deleteBook);
            }
        }

        

    }
}
