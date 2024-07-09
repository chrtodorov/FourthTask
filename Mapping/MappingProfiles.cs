using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Entities;

namespace WebApplication1.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<Shift, ShiftDto>().ReverseMap();
    }
}