using Todo.MAUI.ViewModels;
namespace Todo.MAUI.Views;

public partial class ConcertPage : ContentPage
{
	public ConcertPage(ConcertPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Run the ViewModel's command
        if (BindingContext is ConcertPageVM vm && vm.PageAppearingCommand.CanExecute(null))
        {
            vm.PageAppearingCommand.Execute(null);
        }
    }
}