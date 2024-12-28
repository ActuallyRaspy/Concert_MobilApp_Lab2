using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            LoadConcerts();
            PageAppearingCommand = new Command(OnPageAppearing);
        }
        public async Task LoadConcerts()
        {
            var concertlist = await concertservice.GetConcertsAsync();
            Concerts = concertlist.ToList();
        }
        private void OnPageAppearing()
        {
            LoadConcerts();
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
                    await Shell.Current.DisplayAlert("Error", "Unable to navigate to details page" + ex.Message, "OK");
                }
            }
        }
    }
}
