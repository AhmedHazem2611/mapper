using FirstApiProject.DTOs;
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

        public SubjectController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetSubjects()
        {
            var subjects = _context.Subjects.ToList();
            var subjectsDTO = new List<SubjectDTO>();

            foreach (var subject in subjects)
            {
                var subjectDTO = new SubjectDTO
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,
                    MaxGrade = subject.MaxGrade,
                    TeacherId = subject.TeacherId
                };
                subjectsDTO.Add(subjectDTO);
            }
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
            SubjectDTO subjectDTO = new SubjectDTO();
            subjectDTO.Id = subject.Id;
            subjectDTO.Name = subject.Name;
            subjectDTO.Description = subject.Description;
            subjectDTO.MaxGrade = subject.MaxGrade;
            subjectDTO.TeacherId = subject.TeacherId;
            return Ok(subjectDTO);
        }
        [HttpPost]
        public IActionResult PostSubject(CreateSubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid || subjectDTO == null)
            {
                return BadRequest();
            }
            Subject subject = new Subject();
            subject.Name = subjectDTO.Name;
            subject.Description = subjectDTO.Description;
            subject.MaxGrade = subjectDTO.MaxGrade;
            subject.TeacherId = subjectDTO.TeacherId;

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
        public IActionResult UpdateDepartment(int id, CreateDepartmentDTO departmentDTO)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} was not found.");
            }
            department.Name = departmentDTO.Name;
            department.Description = departmentDTO.Description;
            _context.Departments.Update(department);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchDepartment(int id, string Name)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} was not found.");
            }
            department.Name = Name;
            _context.Departments.Update(department);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
