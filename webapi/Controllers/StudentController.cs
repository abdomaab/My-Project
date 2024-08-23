using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationdbContext context;
        public StudentController(ApplicationdbContext context)
        {
            this.context = context;
        }
        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            var Student = await context.Students.ToListAsync();
            return Ok(Student);
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync([FromBody]StudentDto dto)
        {

            var Student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth
            };

            await context.Students.AddAsync(Student);
            await context.SaveChangesAsync();
            return Ok(Student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpadatAsync(int id, [FromBody] StudentDto dto)
        {

            var student = context.Students.FindAsync(id);
            if (student == null)
                return BadRequest($"No Stuednt was found with id: {id}");

            var students = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                
                

            };
            context.Students.Update(students);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Student =  context.Students.FindAsync(id);
            if (Student == null)
                return BadRequest($"No Student was found with id: {id}");
            context.Remove(Student);
            await context.SaveChangesAsync();
            return Ok(Student);
        }
    }
}
