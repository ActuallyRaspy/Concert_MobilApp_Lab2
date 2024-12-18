using AutoMapper;
using Todo.Data.DTO;
using Todo.MAUI.Models;

namespace TodoREST.Profiles;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        // Map Model to DTO
        // Note that "dest.Name" gets its value from "src.TaskName"
        CreateMap<TodoItem, BookingDto>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TaskName))
        .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
        .ForMember(dest => dest.Done, opt => opt.MapFrom(src => src.Done));

        // Map DTO to Model
        // Note that "dest.TaskName" gets its value from "src.Name"
        CreateMap<BookingDto, TodoItem>()
        .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
        .ForMember(dest => dest.TaskName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
        .ForMember(dest => dest.Done, opt => opt.MapFrom(src => src.Done));

        //CreateMap<TodoItem, TodoItemDto>().ReverseMap();
    }
}