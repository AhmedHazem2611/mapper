using AutoMapper;
using FirstApiProject.DTOs;
using FirstApiProject.Models;

namespace FirstApiProject.MappingProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile() 
        {
            CreateMap<Subject, SubjectDTO>();
            CreateMap<CreateSubjectDTO, SubjectDTO>();
        }
    }
}
