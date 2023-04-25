using AutoMapper;
using STEAM.Database.Entities;
using STEAM.Models.Project;
using STEAM.Models.Photos;
using STEAM.Models.Contacts;


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
        
        CreateMap<AddContactDTO, Contact>().ReverseMap();
        CreateMap<GetContactDTO, Contact>().ReverseMap();
        CreateMap<UpdateContactDTO, Contact>()
            .ForMember(x => x.Message, option => option.Ignore())
            .ForMember(x => x.Name, option => option.Ignore())
            .ForMember(x => x.Email, option => option.Ignore())
            .ReverseMap();

    }
}

