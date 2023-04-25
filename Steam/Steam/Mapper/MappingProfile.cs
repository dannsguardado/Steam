using AutoMapper;
using STEAM.Database.Entities;
using STEAM.Models.Project;
using STEAM.Models.Photos;


namespace STEAM.Mapper;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddProjectDTO, Project>().ReverseMap();
        CreateMap<GetProjectDTO, Project>().ReverseMap();
        CreateMap<UpdateProjectDTO, Project>().ReverseMap();

        CreateMap<AddPhotoDTO, Photo>().ReverseMap();
        CreateMap<GetPhotoDTO, Photo>().ReverseMap();
        CreateMap<UpdatePhotoDTO, Photo>().ReverseMap();
    }
}

