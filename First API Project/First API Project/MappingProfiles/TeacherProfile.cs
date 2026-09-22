using AutoMapper;
using FirstApiProject.DTOs;
using FirstApiProject.Models;
namespace FirstApiProject.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile() 
        {
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<CreateTeacherDTO, TeacherDTO>();
        }
    }
}
