using AutoMapper;
using WebApp.Business.Models;
using WebApp.Data.Entities;

namespace WebApp.Business.Profiles;

public class OrganisationProfile : Profile
{
    public OrganisationProfile()
    {
        CreateMap<Organisation, OrganisationDto>()
            .ForMember(
                dest => dest.EmployeesNumber,
                opt => opt.MapFrom(src => src.Employees != null ? src.Employees.Count : 0));
    }
}