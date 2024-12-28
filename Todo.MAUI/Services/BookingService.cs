using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public class BookingService : IBookingService
{
    IRestService _restService;

    public BookingService(IRestService service)
    {
        _restService = service;
    }

    public Task<List<Booking>?> GetBookingsAsync()
    {
        return _restService.RefreshBookingsAsync();
    }
    public Task SaveBookingAsync(Booking booking, bool isNewBooking = false)
    {
        return _restService.SaveBookingAsync(booking, isNewBooking);
    }

    public Task DeleteBookingAsync(Booking booking)
    {
        return _restService.DeleteBookingAsync(booking.ID);
    }
}