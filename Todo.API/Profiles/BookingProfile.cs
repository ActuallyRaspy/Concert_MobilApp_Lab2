using AutoMapper;
using Todo.Data.DTO;
using Todo.Data.Entity;

namespace TodoAPI.Profiles;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<Booking, BookingDto>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.PerformanceID, opt => opt.MapFrom(src => src.PerformanceID))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

        CreateMap<BookingDto, Booking>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.PerformanceID, opt => opt.MapFrom(src => src.PerformanceID))
        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}