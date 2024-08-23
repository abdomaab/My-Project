using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ApplicationdbContext context;
        public CollegeController(ApplicationdbContext context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAsync()
        {
            var College = context.Colleges.ToListAsync();
            return Ok(College);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Join = (from c in context.Colleges
                        join s in context.Specializations
                        on c.SpecializationId equals s.Id
                        join st in context.Students
                        on s.StudentId equals st.Id
                        select new{
                            c,s,st
                        }).ToList();
            return Ok(Join);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CollegeDto dto)
        {
            var isValidSpecialization = await context.Specializations.AnyAsync(s => s.Id == dto.SpecializationId);
            if (!isValidSpecialization)
                return BadRequest("Invalid id not found");
            
            var College = new College
            {
                Name = dto.Name,
                Affiliation = dto.Affiliation,
                Address = dto.Address,
                SpecializationId = dto.SpecializationId
            };

            await context.Colleges.AddAsync(College);
            await context.SaveChangesAsync();
            return Ok(College);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdayeAsync(int id, CollegeDto dto)
        {

            
            var isValidStuden = await context.Specializations.AnyAsync(s => s.Id == dto.SpecializationId);
            if (!isValidStuden)
                return BadRequest("Invalid id not found");
            
            var College =  context.Colleges.FindAsync(id);
            if (College == null)
                return BadRequest($"No College was found with id: {id}");
            
            var Colleges = new College
            {
                Name = dto.Name,
                Affiliation = dto.Affiliation,
                Address = dto.Address,
                SpecializationId = dto.SpecializationId
                
            };

            context.Colleges.Update(Colleges);
            await context.SaveChangesAsync();
            return Ok(College);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var College = context.Colleges.FindAsync(id);
            if (College == null)
                return BadRequest($"No College was found with id: {id}");
            context.Remove(College);
            await context.SaveChangesAsync();
            return Ok(College);
        }
    }
}
