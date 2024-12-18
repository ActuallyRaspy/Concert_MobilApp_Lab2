using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.MAUI.Models;
using Todo.MAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.MAUI.ViewModels
{
    public partial class BookingsPageVM : ObservableObject
    {
        private readonly IConcertService concertservice;

        [ObservableProperty]
        public string text;

        [RelayCommand]
        public async Task Test()
        {
            List <Concert> test = new(await concertservice.GetConcertsAsync() ?? []);
            foreach (Concert concert in test) {
                text += concert.Title; }
        }
        public BookingsPageVM(IConcertService concertservice)
        {
            this.concertservice = concertservice;
        }

    }
}
