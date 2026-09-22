using AutoMapper;
using FirstApiProject.DTOs;
using FirstApiProject.Models;
namespace FirstApiProject.MappingProfiles
{
    public class ClassroomProfile : Profile
    {
        public ClassroomProfile()
        {
            CreateMap<Classroom, ClassroomDTO>();
            CreateMap<CreateClassroomDTO, Classroom>();
        }
    }
}
