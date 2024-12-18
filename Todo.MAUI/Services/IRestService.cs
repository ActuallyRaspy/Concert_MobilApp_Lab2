using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public interface IRestService
{
    Task<List<Concert>?> RefreshDataAsync();
    Task SaveConcertAsync(Concert concert, bool isNewConcert);
    Task DeleteConcertAsync(string id);
}