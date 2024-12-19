using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.MAUI.ViewModels
{
    public partial class BookPerformancePageVM : ObservableObject
    {
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
    }
}
