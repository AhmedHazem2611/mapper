using AutoMapper;
using FirstApiProject.DTOs;
using FirstApiProject.Models;

namespace FirstApiProject.MappingProfiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDTO>();
            CreateMap<CreateEnrollmentDTO, Enrollment>();
        }
    }
}
