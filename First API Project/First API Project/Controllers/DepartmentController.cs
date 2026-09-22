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
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentController()
        {
            _context = new AppDbContext();
            var config = new MapperConfiguration(a => a.AddProfile<DepartmentProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        public IActionResult GetDepartments()
        {
            var departments = _context.Departments.ToList();
            var departmentsDTO = _mapper.Map<List<DepartmentDTO>>(departments);
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
            DepartmentDTO departmentDTO = _mapper.Map<DepartmentDTO>(department);
            return Ok(departmentDTO);
        }
        [HttpPost]
        public IActionResult PostDepartment(CreateDepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid || departmentDTO == null)
            {
                return BadRequest();
            }
            Department department = _mapper.Map<Department>(departmentDTO);
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
            _mapper.Map(departmentDTO, department);
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
