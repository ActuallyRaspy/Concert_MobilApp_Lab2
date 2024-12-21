using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.MAUI.Services;
using Todo.MAUI.Models;
using System.Windows.Input;


namespace Todo.MAUI.ViewModels
{
    [QueryProperty(nameof(ID), "id")]
    public partial class ConcertDetailsPageVM : ObservableObject
    {
        private IConcertService _concertService;
        private IPerformanceService _performanceService;

        public ConcertDetailsPageVM(IConcertService concertService, IPerformanceService performanceService)
        {
            _concertService = concertService;
            _performanceService = performanceService;
        }

        [ObservableProperty]
        private Performance selectedPerformance;

        [ObservableProperty]
        private string iD;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;
        [ObservableProperty]
        private IEnumerable<Performance> performances;

        partial void OnIDChanged(string value)
        {
            // Call LoadConcert with the new ID
            if (!string.IsNullOrEmpty(value))
            {
                LoadConcert(value);
            }
        }

        [RelayCommand]
        private static async Task GoBack()
        {
            try
            {
                await Shell.Current.GoToAsync($"///ConcertPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "You cant go back, heres why:" + ex.Message, "OK");
            }
        }
        public async Task LoadConcert(string id)
        {
            try
            {
                List<Concert> concertList = await _concertService.GetConcertsAsync();
                Concert concert = concertList.FirstOrDefault(c => c.ID == id);
                Title = concert.Title;
                Description = concert.Description;
                IEnumerable<Performance> performanceList = await _performanceService.GetPerformancesAsync();
                Performances = performanceList.Where(c => c.ConcertID == id);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Concert couldnt be loaded: " + ex.Message, "OK");
            }
        }

        [RelayCommand]
        private async Task NavigateToBooking(Performance performance)
        {
            if (performance != null)
            {
                try
                {
                    SelectedPerformance = null;
                    await Shell.Current.GoToAsync($"///BookPerformancePage?id={performance.ID}");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", "Unable to navigate to Performance page" + ex.Message, "OK");
                }
            }
        }
    }
}
