using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.MAUI.Models;
using Todo.MAUI.Services;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.MAUI.ViewModels
{
    public partial class BookingsPageVM : ObservableObject
    {
        private readonly IBookingService _bookingService;
        private readonly IPerformanceService _performanceService;
        private readonly IConcertService _concertService;



        [ObservableProperty]
        public string text="";
        [ObservableProperty]
        public ICollection<Booking> bookings;

        [RelayCommand]
        public async Task Test()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            var performances = await _performanceService.GetPerformancesAsync();
            var concerts = await _concertService.GetConcertsAsync();
            if (Text.Length>0)
            bookings = bookings.Where(booking => booking.Email.Equals(Text, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var performance in performances)
            {
                performance.Concert = concerts.FirstOrDefault(c => c.ID == performance.ConcertID);
            }
            foreach (var booking in bookings)
            {
                booking.Performance = performances.FirstOrDefault(c => c.ID == booking.PerformanceID);
            }
            Bookings = bookings;
        }
        public BookingsPageVM(IBookingService bookingService, IPerformanceService performanceService, IConcertService concertService)
        {
            _bookingService = bookingService;
            _performanceService = performanceService;
            _concertService = concertService;
        }

    }
}
