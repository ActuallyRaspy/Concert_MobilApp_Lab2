using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data.DTO;
using Todo.MAUI.Models;
using Todo.MAUI.Services;


namespace Todo.MAUI.ViewModels
{
    [QueryProperty(nameof(ID), "id")]
    public partial class BookPerformancePageVM : ObservableObject
    {
        private IConcertService _concertService;
        private IPerformanceService _performanceService;
        private IBookingService _bookingService;


        public BookPerformancePageVM(IConcertService concertService, IPerformanceService performanceService, IBookingService bookingService)
        {
            _concertService = concertService;
            _performanceService = performanceService;
            _bookingService = bookingService;
        }
        [ObservableProperty]
        private string iD;
        [ObservableProperty]
        private Concert chosenConcert;
        [ObservableProperty]
        private Performance chosenPerformance;
        [ObservableProperty]
        private string nameInput;
        [ObservableProperty]
        private string emailInput;
        partial void OnIDChanged(string value)
        {
            // Call LoadConcert with the new ID
            if (!string.IsNullOrEmpty(value))
            {
                LoadPerformance(value);
            }
        }
        async Task LoadPerformance(string id)
        {
            try
            {
                List<Performance> performanceList = await _performanceService.GetPerformancesAsync();
                Performance performance = performanceList.FirstOrDefault(c => c.ID == id);
                ChosenPerformance = performance;
                List<Concert> concertList = await _concertService.GetConcertsAsync();
                ChosenConcert = concertList.FirstOrDefault(c => c.ID == performance.ConcertID);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Concert couldnt be loaded: " + ex.Message, "OK");
            }
        }
        [RelayCommand]
        private static async Task GoBack()
        {
            try
            {
                await Shell.Current.GoToAsync($"///ConcertDetailsPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "You cant go back, heres why:" + ex.Message, "OK");
            }
        }
        [RelayCommand]
        private async Task BookPerformance()
        {
            try
            {
                // Validate user input
                if (string.IsNullOrWhiteSpace(NameInput) || string.IsNullOrWhiteSpace(EmailInput))
                {
                    await Shell.Current.DisplayAlert("Error", "Name and Email are required.", "OK");
                    return;
                }

                if (ChosenPerformance == null)
                {
                    await Shell.Current.DisplayAlert("Error", "Please select a performance to book.", "OK");
                    return;
                }

                // Create BookingDto object
                var booking = new Booking
                {
                    ID = Guid.NewGuid().ToString(), // Generate a unique ID for the booking
                    Name = NameInput,
                    Email = EmailInput,
                    PerformanceID = ChosenPerformance.ID,
                    Performance = null
                };

                // Call API to create booking
                await _bookingService.SaveBookingAsync(booking, true);
                await Shell.Current.DisplayAlert("Success", "You have booked the performance", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
