using AutoMapper;
using WebApp.Business.Models;
using WebApp.Data.Entities;

namespace WebApp.Business.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(
                dest => dest.OrganisationName,
                opt => opt.MapFrom(src => src.Organisation.OrganisationName));
    }
}