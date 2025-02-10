using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class ConcertPage : ContentPage
{
    public ConcertPage(ConcertPageVM vm)
    {
        InitializeComponent();
        BindingContext = vm; // Set the ViewModel as the BindingContext
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ConcertPageVM vm && vm.PageAppearingCommand.CanExecute(null))
        {
            vm.PageAppearingCommand.Execute(null);
        }
    }
}