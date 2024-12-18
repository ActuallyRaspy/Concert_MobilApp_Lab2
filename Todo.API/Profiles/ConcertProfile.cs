using AutoMapper;
using Todo.Data.DTO;
using Todo.Data.Entity;

namespace TodoAPI.Profiles;

public class ConcertProfile : Profile
{
    public ConcertProfile()
    {
        CreateMap<Concert, ConcertDto>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.Performances));

        CreateMap<ConcertDto, Concert>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.Performances));
    }
}
