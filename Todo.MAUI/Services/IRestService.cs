using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public interface IRestService
{
    Task<List<Concert>?> RefreshDataAsync();
    Task<List<Performance>?> RefreshPerformancesAsync();
    Task SaveConcertAsync(Concert concert, bool isNewConcert);
    Task DeleteConcertAsync(string id);
    Task SavePerformanceAsync(Performance performance, bool isNewPerformance);
    Task DeletePerformanceAsync(string id);
    Task<List<Booking>?> RefreshBookingsAsync();
    Task SaveBookingAsync(Booking booking, bool isNewBooking);
    Task DeleteBookingAsync(string id);
}