using AutoMapper;
using FirstApiProject.DTOs;
using FirstApiProject.MappingProfiles;
using FirstApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EnrollmentController()
        {
            _context = new AppDbContext();
            var config = new MapperConfiguration(a => a.AddProfile<EnrollmentProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var enrollments = _context.Enrollments.ToList();
            var enrollmentsDTO = _mapper.Map<List<EnrollmentDTO>>(enrollments);
            return Ok(enrollmentsDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                return NotFound($"enrollment with ID {id} was not found.");
            }
            EnrollmentDTO enrollmentDTO = _mapper.Map<EnrollmentDTO>(enrollment);
            return Ok(enrollmentDTO);
        }
        [HttpPost]
        public IActionResult PostEnrollment(CreateEnrollmentDTO enrollmentDTO)
        {
            if (!ModelState.IsValid || enrollmentDTO == null)
            {
                return BadRequest();
            }
            Enrollment enrollment = _mapper.Map<Enrollment>(enrollmentDTO);

            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                return NotFound($"Enrollment with ID {id} was not found.");
            }
            _context.Enrollments.Remove(enrollment);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id, CreateEnrollmentDTO enrollmentDTO)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                return NotFound($"Enrollment with ID {id} was not found.");
            }
            _mapper.Map(enrollmentDTO, enrollment);
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEnrollments(int id, int studentId)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                return NotFound($"Enrollment with ID {id} was not found.");
            }
            enrollment.StudentId = studentId;
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
