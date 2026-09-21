using FirstApiProject.DTOs;
using FirstApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeacherController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _context.Teachers.ToList();
            var teachersDTO = new List<TeacherDTO>();

            foreach (var teacher in teachers)
            {
                var teacherDTO = new TeacherDTO
                {
                    Id = teacher.Id,
                    FirstName = teacher.FirstName,
                    LastName = teacher.LastName,
                    EmailAddress = teacher.EmailAddress,
                    PhoneNumber = teacher.PhoneNumber,
                    Salary = teacher.Salary,
                    DepartmentId = teacher.DepartmentId,
                    DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == teacher.DepartmentId)?.Name
                };
                teachersDTO.Add(teacherDTO);
            }
            return Ok(teachersDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetTeachers(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound($"Teacher with ID {id} was not found.");
            }
            TeacherDTO teacherDTO = new TeacherDTO();
            teacherDTO.Id = teacher.Id;
            teacherDTO.FirstName = teacher.FirstName;
            teacherDTO.LastName = teacher.LastName;
            teacherDTO.EmailAddress = teacher.EmailAddress;
            teacherDTO.PhoneNumber = teacher.PhoneNumber;
            teacherDTO.Salary = teacher.Salary;
            teacherDTO.DepartmentId = teacher.DepartmentId;
            teacherDTO.DepartmentName = _context.Departments.FirstOrDefault(x => x.Id == teacher.DepartmentId)?.Name;
            return Ok(teacherDTO);
        }
        [HttpPost]
        public IActionResult PostTeacher(CreateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid || teacherDTO == null)
            {
                return BadRequest();
            }
            Teacher teacher = new Teacher();
            teacher.FirstName = teacherDTO.FirstName;
            teacher.LastName = teacherDTO.LastName;
            teacher.EmailAddress = teacherDTO.EmailAddress;
            teacher.PhoneNumber = teacherDTO.PhoneNumber;
            teacher.Salary = teacherDTO.Salary;
            teacher.DepartmentId = teacherDTO.DepartmentId;
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound($"Teacher with ID {id} was not found.");
            }
            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, CreateTeacherDTO teacherDTO)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound($"Teacher with ID {id} was not found.");
            }
            teacher.FirstName = teacherDTO.FirstName;
            teacher.LastName = teacherDTO.LastName;
            teacher.EmailAddress = teacherDTO.EmailAddress;
            teacher.PhoneNumber = teacherDTO.PhoneNumber;
            teacher.Salary = teacherDTO.Salary;
            teacher.DepartmentId = teacherDTO.DepartmentId;
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchTeacher(int id, string Name)
        {
            var teacher = _context.Teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound($"Teacher with ID {id} was not found.");
            }
            teacher.FirstName = Name;
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
