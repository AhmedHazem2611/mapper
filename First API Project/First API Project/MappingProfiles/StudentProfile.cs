using AutoMapper;
using FirstApiProject.Models;
using FirstApiProject.DTOs;
namespace FirstApiProject.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(des => des.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<CreateStudentDTO, Student>()
                .ForMember(des => des.FirstName,
                opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)[0]))

                .ForMember(des => des.LastName,
                opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries)[1]));
        }
    }
}