using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}