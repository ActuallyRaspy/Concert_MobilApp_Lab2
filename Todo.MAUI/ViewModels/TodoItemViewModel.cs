using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Todo.MAUI.Models;
using Todo.MAUI.Services;

namespace Todo.MAUI.ViewModels;

[ObservableObject]
[QueryProperty("Item", nameof(TodoItem))]
public partial class TodoItemViewModel
{
    private bool _isNewItem;
    private ITodoService _todoService;

    [ObservableProperty] private TodoItem item = null!;

    partial void OnItemChanging(TodoItem value)
    {
        _isNewItem = IsNewItem(value);
    }

    public TodoItemViewModel(ITodoService todoService)
    {
        _todoService = todoService;
    }

    private bool IsNewItem(TodoItem todoItem)
    {
        if (string.IsNullOrWhiteSpace(todoItem.TaskName) &&
        string.IsNullOrWhiteSpace(todoItem.Notes))
            return true;
        return false;
    }

    [RelayCommand]
    public async Task Save()
    {
        await _todoService.SaveTaskAsync(Item, _isNewItem);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task Delete()
    {
        await _todoService.DeleteTaskAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    public async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}