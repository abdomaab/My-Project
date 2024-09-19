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
        private readonly IBaserepository<Book> _bookRepository;

        public BookController(IBaserepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_bookRepository.GetById(id));
        }

        [HttpPost("Add")]

        public IActionResult Add(BookDto book)
        {
            return Ok(_bookRepository.AddOne(new Book {Name = book.Name = book.Name, Title = book.Title, Description = book.Description, Author = book.Author }));
        }

        [HttpPut("Update{id}")]

        public IActionResult Update(int id,BookDto book)
        {
            var books = _bookRepository.GetById(id);
            if (id == null)
                return BadRequest($"no id was found with your id:{id}");
            return Ok(_bookRepository.Update(id, new Book {Name = book.Name =book.Name, Title = book.Title, Description = book.Description ,Author= book.Author }));
        }
        [HttpDelete("Delete{id}")]
        public IActionResult Delete(int id, BookDto book)
        {
            var books = _bookRepository.GetById(id);
            if (id == null)
                return BadRequest($"no id was found with your id:{id}");
            return Ok(_bookRepository.Delete(books));
        }
    }
}

