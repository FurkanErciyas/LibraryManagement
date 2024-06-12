using BUSINESS.Interfaces;
using ENTITIES.DTO.CreateDTO;
using ENTITIES.DTO.DeleteDTO;
using ENTITIES.DTO.UpdateDTO;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpGet("getall")]
        public IActionResult GetAll() 
        {
            return Ok(_user.GetAll());
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_user.GetSingle(id));
        }

        [HttpPost("add")]
        public IActionResult AddUser(UserCreateDTO user)
        {
            return Ok(_user.AddUser(user));
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(UserDeleteDTO user)
        {
            return Ok(_user.DeleteUser(user));
        }

        [HttpPut("update")]
        public IActionResult UpdateUser(UserUpdateDTO user)
        {
            return Ok(_user.UpdateUser(user));
        }

        [HttpGet("borrowbook")]
        public IActionResult BorrowBook(int userId, int bookId)
        {
            return Ok(_user.BorrowBook(userId, bookId));
        }

        [HttpGet("returnbook")]
        public IActionResult ReturnBook(int userId, int bookId)
        {
            return Ok(_user.ReturnBook(userId, bookId));
        }

        [HttpGet("bookrecords")]
        public IActionResult BookRecords(int userId)
        {
            return Ok(_user.BookRecords(userId));
        }
    }
}
