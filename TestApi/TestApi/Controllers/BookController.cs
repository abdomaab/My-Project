using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.EF.Models;
using TestApi.NetCore.Dto;
using TestApi.NetCore.Interfaces;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;

        public BookController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        [HttpGet("{id}")]
   
        public IActionResult GetById(int id)
        {
            return Ok(_unityOfWork.Books.GetById(id));
        }

        [HttpPost("Add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(BookDto book)
        {
            var Book = _unityOfWork.Books.AddOne(new Book { Name = book.Name = book.Name, Title = book.Title, Description = book.Description, Author = book.Author });
            _unityOfWork.Complete();
            return Ok(Book);
        }

        [HttpPut("Update{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id,BookDto book)
        {
            var books = _unityOfWork.Books.GetById(id);
            if (id == null)
                return BadRequest($"no id was found with your id:{id}");
            var Book = _unityOfWork.Books.Update(id, new Book { Name = book.Name = book.Name, Title = book.Title, Description = book.Description, Author = book.Author });
            _unityOfWork.Complete();
            return Ok(Book);
        }
        [HttpDelete("Delete{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id, BookDto book)
        {
            var books = _unityOfWork.Books.GetById(id);
            if (id == null)
                return BadRequest($"no id was found with your id:{id}");
            var Book = _unityOfWork.Books.Delete(books);
            _unityOfWork.Complete();
            return Ok(Book);
        }
    }
}

