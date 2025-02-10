using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public class ConcertService : IConcertService
{
    private readonly IRestService _restService;

    public ConcertService(IRestService restService)
    {
        _restService = restService ?? throw new ArgumentNullException(nameof(restService));
    }

    public async Task<List<Concert>> GetConcertsAsync()
    {
        try
        {
            var concerts = await _restService.RefreshDataAsync();
            return concerts ?? new List<Concert>();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            Console.WriteLine($"Error fetching concerts: {ex.Message}");
            throw; // Rethrow to ensure visibility of the error
        }
    }

    public Task SaveConcertAsync(Concert concert, bool isNewConcert = false)
    {
        if (concert == null)
            throw new ArgumentNullException(nameof(concert));

        return _restService.SaveConcertAsync(concert, isNewConcert);
    }

    public Task DeleteConcertAsync(Concert concert)
    {
        if (concert == null)
            throw new ArgumentNullException(nameof(concert));

        return _restService.DeleteConcertAsync(concert.ID);
    }
}