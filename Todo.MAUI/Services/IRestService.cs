using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public interface IRestService
{
    Task<List<TodoItem>?> RefreshDataAsync();
    Task SaveTodoItemAsync(TodoItem item, bool isNewItem);
    Task DeleteTodoItemAsync(string id);
}