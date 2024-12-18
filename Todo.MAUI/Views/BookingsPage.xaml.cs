using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class BookingsPage : ContentPage
{
	public BookingsPage(BookingsPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}