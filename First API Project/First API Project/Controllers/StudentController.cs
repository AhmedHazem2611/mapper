using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstApiProject.Models;
using FirstApiProject.DTOs;
using FirstApiProject.MappingProfiles;
using AutoMapper;

namespace FirstApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public StudentController()
        {
            _context = new AppDbContext();
            var config = new MapperConfiguration(a => a.AddProfile<StudentProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList();
            var studentDtos = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentDtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }
            StudentDTO studentDTO = _mapper.Map<StudentDTO>(student);
            return Ok(studentDTO);
        }
        [HttpPost]
        public IActionResult PostStudent(CreateStudentDTO studentDTO)
        {
            if(!ModelState.IsValid || studentDTO == null)
            {
                return BadRequest();
            }
            Student student = _mapper.Map<Student>(studentDTO);
            _context.Students.Add(student);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }
            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, CreateStudentDTO studentDTO)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }
            _mapper.Map(studentDTO, student);
            _context.Students.Update(student);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchStudent(int id, string FirstName)
        {
            var student = _context.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound($"Student with ID {id} was not found.");
            }
            student.FirstName = FirstName;
            _context.Students.Update(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}