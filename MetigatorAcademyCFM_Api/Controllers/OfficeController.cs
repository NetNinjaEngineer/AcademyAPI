using EF010.InitialMigration.Data;
using EF010.InitialMigration.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetigatorAcademyCFM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly AppDbContext context;

        public OfficeController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(Office office)
        {
            if (office == null)
                throw new ArgumentNullException(nameof(office));
            await context.Offices.AddAsync(office);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = office.Id }, office);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var office = await context.Offices.FindAsync(id);
            if (office == null)
                return NotFound();
            return Ok(office);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetAll(
           [FromQuery] int page = 1,
           [FromQuery] int pageSize = 10)
        {
            var officesQueryable = context.Courses.AsQueryable();

            var totalOffices = await officesQueryable.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalOffices / pageSize);
            var results = await officesQueryable.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(results);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Office office)
        {
            var updatedOffice = await context.Offices.FindAsync(id);
            if (updatedOffice == null)
                return NotFound();
            context.Entry(updatedOffice).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var office = await context.Offices.FindAsync(id);
            if (office == null)
                return NotFound();

            context.Offices.Remove(office);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
