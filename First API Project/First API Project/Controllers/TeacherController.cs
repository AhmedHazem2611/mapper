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
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TeacherController()
        {
            _context = new AppDbContext();
            var config = new MapperConfiguration(a => a.AddProfile<TeacherProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _context.Teachers.ToList();
            var teachersDTO = _mapper.Map<List<TeacherDTO>>(teachers);
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
            TeacherDTO teacherDTO = _mapper.Map<TeacherDTO>(teacher);
            return Ok(teacherDTO);
        }
        [HttpPost]
        public IActionResult PostTeacher(CreateTeacherDTO teacherDTO)
        {
            if (!ModelState.IsValid || teacherDTO == null)
            {
                return BadRequest();
            }
            Teacher teacher = _mapper.Map<Teacher>(teacherDTO);
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
            _mapper.Map(teacherDTO,teacher);
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
