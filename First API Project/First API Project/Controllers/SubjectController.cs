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
    public class SubjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SubjectController()
        {
            _context = new AppDbContext();
            var config = new MapperConfiguration(a => a.AddProfile<SubjectProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _context.Subjects.ToList();
            var subjectsDTO = _mapper.Map<List<SubjectDTO>>(subjects);
            return Ok(subjectsDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(x => x.Id == id);
            if (subject == null)
            {
                return NotFound($"Subject with ID {id} was not found.");
            }
            SubjectDTO subjectDTO = _mapper.Map<SubjectDTO>(subject);
            return Ok(subjectDTO);
        }
        [HttpPost]
        public IActionResult PostSubject(CreateSubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid || subjectDTO == null)
            {
                return BadRequest();
            }
            Subject subject = _mapper.Map<Subject>(subjectDTO);

            _context.Subjects.Add(subject);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            var subject = _context.Subjects.FirstOrDefault(x => x.Id == id);
            if (subject == null)
            {
                return NotFound($"Department with ID {id} was not found.");
            }
            _context.Subjects.Remove(subject);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(int id, CreateSubjectDTO subjectDTO)
        {
            var subject = _context.Subjects.FirstOrDefault(x => x.Id == id);
            if (subject == null)
            {
                return NotFound($"Subject with ID {id} was not found.");
            }
            _mapper.Map(subjectDTO,subject);
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchSubject(int id, string Name)
        {
            var subject = _context.Subjects.FirstOrDefault(x => x.Id == id);
            if (subject == null)
            {
                return NotFound($"Subject with ID {id} was not found.");
            }
            subject.Name = Name;
            _context.Subjects.Update(subject);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
