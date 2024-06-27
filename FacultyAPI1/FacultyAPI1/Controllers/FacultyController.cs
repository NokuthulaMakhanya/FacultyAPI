using FacultyAPI1.Data;
using FacultyAPI1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacultyAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        private readonly DataContext _context;

        public FacultyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFaculties()
        {
            var faculties = _context.Faculties.ToList();
            if (faculties.Count > 0)
            {
                return Ok(faculties);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetFaculty(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty != null)
            {
                return Ok(faculty);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddFaculty(Faculty dUTValue)
        {
            dUTValue.FacultyId = 0;

            _context.Faculties.Add(dUTValue);
            _context.SaveChanges();
            return Ok(dUTValue);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFaculty(int id, Faculty dUTValue)
        {
            var existingFaculty = _context.Faculties.Find(id);
            if (existingFaculty != null)
            {
                existingFaculty.FacultyName = dUTValue.FacultyName;
                _context.SaveChanges();
                return Ok(existingFaculty);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaculty(int id)
        {
            var faculty = _context.Faculties.Find(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
    }
}
