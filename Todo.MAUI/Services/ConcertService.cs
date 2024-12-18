using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public class ConcertService : IConcertService
{
    IRestService _restService;

    public ConcertService(IRestService service)
    {
        _restService = service;
    }

    public Task<List<Concert>?> GetConcertsAsync()
    {
        return _restService.RefreshDataAsync();
    }

    public Task SaveConcertAsync(Concert concert, bool isNewConcert = false)
    {
        return _restService.SaveConcertAsync(concert, isNewConcert);
    }

    public Task DeleteConcertAsync(Concert concert)
    {
        return _restService.DeleteConcertAsync(concert.ID);
    }
}