using AutoMapper;
using Todo.Data.DTO;
using Todo.Data.Entity;

namespace Todo.API.Profiles
{
    public class PerformanceProfile : Profile
    {
        public PerformanceProfile()
        {
            CreateMap<Performance, PerformanceDto>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ConcertID, opt => opt.MapFrom(src => src.ConcertID))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dest => dest.Concert, opt => opt.MapFrom(src => src.Concert));

            CreateMap<PerformanceDto, Performance>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.ConcertID, opt => opt.MapFrom(src => src.ConcertID))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dest => dest.Concert, opt => opt.MapFrom(src => src.Concert));
        }
    }
}
