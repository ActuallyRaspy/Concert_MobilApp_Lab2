using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.MAUI.Services;
using Todo.MAUI.Models;


namespace Todo.MAUI.ViewModels
{
    [QueryProperty(nameof(ID), "id")]
    public partial class ConcertDetailsPageVM : ObservableObject
    {
        private IConcertService _concertService;

        public ConcertDetailsPageVM(IConcertService concertService)
        {
            _concertService = concertService;
        }
        [ObservableProperty]
        private Concert selectedConcert;

        [ObservableProperty]
        private string iD;

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;
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
                List<Concert> concertlist = await _concertService.GetConcertsAsync();
                Concert concert = concertlist.FirstOrDefault(c => c.ID == id);
                Title = concert.Title;
                Description = concert.Description;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "Concert couldnt be loaded: " + ex.Message, "OK");
            }
        }
        [RelayCommand]
        public async Task Test()
        {
        }
    }
}
