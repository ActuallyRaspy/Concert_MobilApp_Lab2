using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class ConcertDetailsPage : ContentPage
{
	public ConcertDetailsPage(ConcertDetailsPageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}