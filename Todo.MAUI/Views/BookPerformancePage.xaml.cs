using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class BookPerformancePage : ContentPage
{
	public BookPerformancePage(BookPerformancePageVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}