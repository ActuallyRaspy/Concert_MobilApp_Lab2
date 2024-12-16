using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class TodoListPage : ContentPage
{
    public TodoListPage(TodoListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}