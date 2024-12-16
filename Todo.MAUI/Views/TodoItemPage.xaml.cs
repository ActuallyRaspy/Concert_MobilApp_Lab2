using Todo.MAUI.ViewModels;

namespace Todo.MAUI.Views;

public partial class TodoItemPage : ContentPage
{
    public TodoItemPage(TodoItemViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}