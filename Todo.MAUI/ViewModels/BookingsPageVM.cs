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

        [ObservableProperty]
        public string text;
        [ObservableProperty]
        public ICollection<Booking> bookings;
        [RelayCommand]
        public async Task Test()
        {
            Bookings = await _bookingService.GetBookingsAsync();
        }
        public BookingsPageVM(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

    }
}
