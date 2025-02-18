using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.MAUI.Models;

namespace Todo.MAUI.Services
{
    public interface IBookingService
    {
        Task<List<Booking>?> GetBookingsAsync();
        Task<HttpResponseMessage> SaveBookingAsync(Booking booking, bool isNewBooking);
        Task DeleteBookingAsync(Booking booking);
    }
}
