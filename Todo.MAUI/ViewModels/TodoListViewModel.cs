using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using Todo.MAUI.Models;
using Todo.MAUI.Services;

namespace Todo.MAUI.ViewModels;

[ObservableObject]
public partial class TodoListViewModel
{
    private ITodoService _todoService;

    [ObservableProperty]
    private ObservableCollection<TodoItem> todoItems = new();

    [ObservableProperty]
    private TodoItem? selectedTodoItem;

    public TodoListViewModel(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [RelayCommand]
    public async Task Appearing()
    {
        TodoItems = new(await _todoService.GetTasksAsync() ?? []);
    }

    [RelayCommand]
    public async Task AddItem()
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(TodoItem), new TodoItem() { ID = Guid.NewGuid().ToString() } }
        };
        await Shell.Current.GoToAsync("TodoItemPage", navigationParameter);
    }

    [RelayCommand]
    public async Task SelectionChanged()
    {
        if (SelectedTodoItem == null) return;
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(TodoItem), SelectedTodoItem }
        };
        await Shell.Current.GoToAsync("TodoItemPage", navigationParameter);
    }
}