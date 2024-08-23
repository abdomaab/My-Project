using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializationController : ControllerBase
    {
        private readonly ApplicationdbContext context;
        public SpecializationController(ApplicationdbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            var Specialization = await context.Specializations.ToListAsync();

            return Ok(Specialization);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAsync([FromBody]SpecializationDto dto) 
        {
            var isValidCollege = await context.Students.AnyAsync(s => s.Id == dto.StudentId);
            if (!isValidCollege)
                return BadRequest("Invalid id not found");
            var Specialization = new Specialization
            {
                specializationName = dto.specializationName,
                StudentId = dto.StudentId
            };

            await context.Specializations.AddAsync(Specialization);
            await context.SaveChangesAsync();
            return Ok(Specialization);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateAsync(int id, SpecializationDto dto)
        {
            var isValidCollege =await  context.Students.AnyAsync(s => s.Id == dto.StudentId);
            if (!isValidCollege)
                return BadRequest("Invalid id not found");
            
            var Specializations = context.Specializations.FindAsync(id);
            if (Specializations == null)
                return BadRequest($"No Specialization was found with id: {id}");
            var Specialization = new Specialization
            {
                specializationName = dto.specializationName,
                StudentId = dto.StudentId
            };
            context.Specializations.Update(Specialization);
            await context.SaveChangesAsync();
            return Ok(Specialization);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var Specialization = context.Specializations.FindAsync(id);
            if (Specialization == null)
                return BadRequest($"No Specialization was found with id: {id}");
            context.Remove(Specialization);
            await context.SaveChangesAsync();
            return Ok(Specialization);
        }
    }



}
