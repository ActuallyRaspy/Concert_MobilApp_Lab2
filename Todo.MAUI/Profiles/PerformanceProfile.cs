using AutoMapper;
using Todo.Data.DTO;
using Todo.MAUI.Models;

namespace Todo.MAUI.Profiles
{
    public class PerformanceProfile : Profile
    {
        public PerformanceProfile()
        {
            // Map Model to DTO
            // Note that "dest.Name" gets its value from "src.TaskName"
            CreateMap<Performance, PerformanceDto>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
            .ForMember(dest => dest.ConcertID, opt => opt.MapFrom(src => src.ConcertID))
            .ForMember(dest => dest.Concert, opt => opt.MapFrom(src => src.Concert));



            // Map DTO to Model
            // Note that "dest.TaskName" gets its value from "src.Name"
            CreateMap<PerformanceDto, Performance>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
            .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
            .ForMember(dest => dest.ConcertID, opt => opt.MapFrom(src => src.ConcertID))
            .ForMember(dest => dest.Concert, opt => opt.MapFrom(src => src.Concert));
        }
    }
}
