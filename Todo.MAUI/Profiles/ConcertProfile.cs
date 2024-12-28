using AutoMapper;
using Todo.Data.DTO;
using Todo.MAUI.Models;

namespace Todo.Maui.Profiles;

public class ConcertProfile : Profile
{
    public ConcertProfile()
    {
        // Map Model to DTO
        // Note that "dest.Name" gets its value from "src.TaskName"
        CreateMap<Concert, ConcertDto>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.Performances));

        // Map DTO to Model
        // Note that "dest.TaskName" gets its value from "src.Name"
        CreateMap<ConcertDto, Concert>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.Performances));
    }
}