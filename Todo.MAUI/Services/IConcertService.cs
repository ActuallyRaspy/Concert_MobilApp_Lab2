using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public interface IConcertService
{
    Task<List<Concert>?> GetConcertsAsync();
    Task SaveConcertAsync(Concert concert, bool isNewConcert);
    Task DeleteConcertAsync(Concert concert);
}