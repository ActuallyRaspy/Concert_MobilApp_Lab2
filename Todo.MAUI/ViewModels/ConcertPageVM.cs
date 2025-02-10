using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.MAUI.Models;
using Todo.MAUI.Services;

namespace Todo.MAUI.ViewModels
{
    public partial class ConcertPageVM : ObservableObject
    {
        private readonly IConcertService concertservice;

        public ICommand PageAppearingCommand { get; }

        [ObservableProperty]
        private Concert selectedConcert;

        [ObservableProperty]
        private List<Concert> concerts;

        public ConcertPageVM(IConcertService concertservice)
        {
            this.concertservice = concertservice;
            PageAppearingCommand = new AsyncRelayCommand(OnPageAppearing);
        }

        public async Task LoadConcerts()
        {
            try
            {
                concerts = await concertservice.GetConcertsAsync();
                
                if (concerts != null)
                {
                   concerts = new List<Concert>(concerts); // Force PropertyChanged
                }
                OnPropertyChanged(nameof(concerts)); // Explicit notification

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load concerts: {ex.Message}", "OK");
            }
        }

        private async Task OnPageAppearing()
        {

            await LoadConcerts();
        }

        [RelayCommand]
        private async Task NavigateToDetails(Concert concert)
        {
            if (concert != null)
            {
                try
                {
                    SelectedConcert = null;
                    await Shell.Current.GoToAsync($"///ConcertDetailsPage?id={concert.ID}");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Error", $"Unable to navigate to details page: {ex.Message}", "OK");
                }
            }
        }
    }
}