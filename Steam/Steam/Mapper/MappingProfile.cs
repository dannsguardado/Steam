using AutoMapper;
using STEAM.Database.Entities;
using STEAM.Models.Project;

namespace STEAM.Mapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddProjectDTO, Project>().ReverseMap();
        CreateMap<GetProjectDTO, Project>().ReverseMap();
        CreateMap<UpdateProjectDTO, Project>().ReverseMap();
    }
}

