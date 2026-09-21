using FirstApiProject.DTOs;
using FirstApiProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            var departmentsDTO = new List<DepartmentDTO>();

            foreach (var department in departments)
            {
                var departmentDTO = new DepartmentDTO
                {
                    Id = department.Id,
                    Name = department.Name,
                    Description = department.Description
                    
                };
                departmentsDTO.Add(departmentDTO);
            }
            return Ok(departmentsDTO);
        }
        [HttpGet("{id}")]
        public IActionResult GetDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} was not found.");
            }
            DepartmentDTO departmentDTO = new DepartmentDTO();
            departmentDTO.Id = department.Id;
            departmentDTO.Name = department.Name;
            departmentDTO.Description = department.Description;
            return Ok(departmentDTO);
        }
        [HttpPost]
        public IActionResult PostDepartment(CreateDepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid || departmentDTO == null)
            {
                return BadRequest();
            }
            Department department = new Department();
            department.Name = departmentDTO.Name;
            department.Description = departmentDTO.Description;
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Created();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);
            if (department == null)
            {
                return NotFound($"Department with ID {id} was not found.");
            }
            _context.Departments.Remove(department);
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
