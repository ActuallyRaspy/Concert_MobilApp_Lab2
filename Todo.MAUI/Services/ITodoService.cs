using Todo.MAUI.Models;

namespace Todo.MAUI.Services;

public interface ITodoService
{
    Task<List<TodoItem>?> GetTasksAsync();
    Task SaveTaskAsync(TodoItem item, bool isNewItem);
    Task DeleteTaskAsync(TodoItem item);
}