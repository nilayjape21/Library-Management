using Microsoft.AspNetCore.Mvc;
using MyLibrary_BooksAPIs.Data;
using MyLibrary_BooksAPIs.Models.DTO;

namespace MyLibrary_BooksAPIs.Controllers
{
    //[Route("/[controller]")]   // To automate the controller name to route name.
    [Route("/Books")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        [HttpGet]

        //ActionResult is implementation of interface IActionResult
        public ActionResult<IEnumerable<BooksDTO>> GetBooks()  // If id is not given then all the list of books will be shown.
        {
            return Ok(BooksStore.BooksList);
        }
        [HttpGet("{id:int}")] // It explicitly accepts only int datatype.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BooksDTO> GetBook(int id) // If id is given then the only a book with that id will be shown.
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var books = BooksStore.BooksList.FirstOrDefault(u => u.Id == id);

            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }

        [HttpPost]

        public ActionResult<BooksDTO> CreateBook([FromBody]BooksDTO bookDTO)
        {
           if(bookDTO == null)
            {
                return BadRequest();
            }
           if(bookDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            bookDTO.Id = BooksStore.BooksList.OrderByDescending(u => u.Id).FirstOrDefault().Id+1;
            BooksStore.BooksList.Add(bookDTO);

            return Ok(bookDTO);

        }
    
    }
}
