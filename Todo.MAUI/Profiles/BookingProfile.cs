using AutoMapper;
using Todo.Data.DTO;
using Todo.MAUI.Models;

namespace Todo.MAUI.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Map Model to DTO
            // Note that "dest.Name" gets its value from "src.TaskName"
            CreateMap<Booking, BookingDto>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PerformanceID, opt => opt.MapFrom(src => src.PerformanceID))
            .ForMember(dest => dest.Performance, opt => opt.MapFrom(src => src.Performance));


            // Map DTO to Model
            // Note that "dest.TaskName" gets its value from "src.Name"
            CreateMap<BookingDto, Booking>()
            .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.PerformanceID, opt => opt.MapFrom(src => src.PerformanceID))
            .ForMember(dest => dest.Performance, opt => opt.MapFrom(src => src.Performance));
        }
    }
}
