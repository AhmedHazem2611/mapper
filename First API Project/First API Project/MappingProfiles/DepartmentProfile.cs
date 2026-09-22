using AutoMapper;
using FirstApiProject.DTOs;
using FirstApiProject.Models;

namespace FirstApiProject.MappingProfiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<CreateDepartmentDTO, Department>(); 
        }
    }
}
