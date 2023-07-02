using EF010.InitialMigration.Data;
using EF010.InitialMigration.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetigatorAcademyCFM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private ILogger<StudentController> _logger;
        private readonly AppDbContext _context;

        public StudentController(ILogger<StudentController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            if (student == null) 
                throw new ArgumentNullException(nameof(student));
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Create), student);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll(
            [FromQuery] string? firstName = null,
            [FromQuery] string? lastName = null, 
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var studentsQueryable = _context.Students.AsQueryable();
            if (!string.IsNullOrEmpty(firstName))
            {
                studentsQueryable = studentsQueryable.Where(x=> x.FName!.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                studentsQueryable = studentsQueryable.Where(x => x.LName!.Contains(lastName));
            }

            var totalStudens = await studentsQueryable.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalStudens / pageSize);
            var results = await studentsQueryable.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            Student? student = await _context.Students.SingleOrDefaultAsync(x => x.Id == id);
            if (student == null)
                return  NotFound();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if (id != student.Id)
                return BadRequest();

            var existStudent = await _context.Students.FindAsync(id);
            if (existStudent == null)
                return NotFound();

            existStudent.FName = student.FName;
            existStudent.LName = student.LName;
            existStudent.Enrollments = student.Enrollments;
            existStudent.Sections = student.Sections;

            _context.Entry(existStudent).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete(template: "{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.SingleAsync(x=> x.Id == id);
            if (student == null)
                return NotFound();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
