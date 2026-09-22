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
    public class ClassroomController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassroomController()
        {
            _context = new AppDbContext();
            var config = new MapperConfiguration(a => a.AddProfile<ClassroomProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetClassrooms()
        {
            var classrooms = _context.Classrooms.ToList();
            var classroomsDTO = _mapper.Map<List<ClassroomDTO>>(classrooms);
            return Ok(classroomsDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetClassroom(int id)
        {
            var classroom = _context.Classrooms.FirstOrDefault(x => x.Id == id);
            if (classroom == null)
            {
                return NotFound($"classroom with ID {id} was not found.");
            }
            ClassroomDTO classroomDTO = _mapper.Map<ClassroomDTO>(classroom);
            return Ok(classroomDTO);
        }
        [HttpPost]
        public IActionResult PostClassroom(CreateClassroomDTO classroomDTO)
        {
            if (!ModelState.IsValid || classroomDTO == null)
            {
                return BadRequest();
            }
            Classroom classroom = _mapper.Map<Classroom>(classroomDTO);

            _context.Classrooms.Add(classroom);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClassroom(int id)
        {
            var classroom = _context.Classrooms.FirstOrDefault(x => x.Id == id);
            if (classroom == null)
            {
                return NotFound($"classroom with ID {id} was not found.");
            }
            _context.Classrooms.Remove(classroom);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClassroom(int id, CreateClassroomDTO classroomDTO)
        {
            var classroom = _context.Classrooms.FirstOrDefault(x => x.Id == id);
            if (classroom == null)
            {
                return NotFound($"classroom with ID {id} was not found.");
            }
            _mapper.Map(classroomDTO, classroom);
            _context.Classrooms.Update(classroom);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchClassrooms(int id, string Name)
        {
            var classroom = _context.Classrooms.FirstOrDefault(x => x.Id == id);
            if (classroom == null)
            {
                return NotFound($"classroom with ID {id} was not found.");
            }
            classroom.Name = Name;
            _context.Classrooms.Update(classroom);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
