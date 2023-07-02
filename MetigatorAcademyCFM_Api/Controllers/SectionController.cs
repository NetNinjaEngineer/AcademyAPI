using EF010.InitialMigration.Data;
using EF010.InitialMigration.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetigatorAcademyCFM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ILogger<SectionController> _logger; 
        private readonly AppDbContext _context;

        public SectionController(ILogger<SectionController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Section>> Create(Section section)
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section));
            await _context.Sections.AddAsync(section);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), section);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Section>> GetById(int id)
        {
            var student = await _context.Sections.FindAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Section>>> GetAll(
           [FromQuery] string? sectionName = null,
           [FromQuery] int page = 1,
           [FromQuery] int pageSize = 10)
        {
            var sectionsQueryable = _context.Sections.AsQueryable();
            if (!string.IsNullOrEmpty(sectionName))
            {
                sectionsQueryable = sectionsQueryable.Where(x => x.SectionName!.Contains(sectionName));
            }

            var totalStudens = await sectionsQueryable.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalStudens / pageSize);
            var results = await sectionsQueryable.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(results);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Section section)
        {
           if (id != section.Id)
                return BadRequest();
            Section? existingSection = await _context.Sections.FindAsync(id);
            if (existingSection == null)
                return NotFound();

            existingSection.SectionName = section.SectionName;
            existingSection.Students = section.Students;
            existingSection.Course = section.Course;
            existingSection.Enrollments = section.Enrollments;
            existingSection.InstructorId = section.InstructorId;
            existingSection.Instructor = section.Instructor;

            _context.Entry(existingSection).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await _context.Sections.FirstOrDefaultAsync(x => x.Id == id);
            if (section == null)
                return NotFound(nameof(section));
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
