using BUSINESS.Interfaces;
using ENTITIES.DTO.CreateDTO;
using ENTITIES.DTO.DeleteDTO;
using ENTITIES.DTO.UpdateDTO;
using ENTITIES.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBook _book;

        public BookController(IBook book)
        {
            _book = book;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            return Ok(_book.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id) 
        {
            return Ok(_book.GetSingle(id));
        }

        [HttpPost("add")]
        public IActionResult AddBook(BookCreateDTO book)
        {
            return Ok(_book.AddBook(book));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteBook(BookDeleteDTO book) 
        {
            return Ok(_book.DeleteBook(book));
        }

        [HttpPut("update")]
        public IActionResult UpdateBook(BookUpdateDTO book) 
        {
            return Ok(_book.UpdateBook(book));
        }

        [HttpGet("userrecords")]
        public IActionResult UserRecords(int bookId)
        {
            return Ok(_book.UserRecords(bookId));
        }

    }
}
