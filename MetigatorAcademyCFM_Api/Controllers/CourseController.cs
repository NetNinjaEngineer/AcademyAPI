using EF010.InitialMigration.Data;
using EF010.InitialMigration.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace MetigatorAcademyCFM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly AppDbContext _context;

        public CourseController(ILogger<CourseController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> Create(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));
            course.CreatedAt = DateTime.UtcNow;
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetById(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAll(
           [FromQuery] string? courseName = null,
           [FromQuery] int page = 1,
           [FromQuery] int pageSize = 10)
        {
            var coursesQueryable = _context.Courses.AsQueryable();
            if (!string.IsNullOrEmpty(courseName))
            {
                coursesQueryable = coursesQueryable.Where(x => x.CourseName!.Contains(courseName));
            }

            var totalCourses = await coursesQueryable.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCourses / pageSize);
            var results = await coursesQueryable.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(results);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Course course)
        {
            var targetCourse = await _context.Courses.FindAsync(id);
            if (targetCourse == null)
                return NotFound();
            targetCourse.CourseName = course.CourseName;
            targetCourse.Price = course.Price;
            targetCourse.CreatedAt = course.CreatedAt;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
