namespace Todo.Data.DTO;

public class TodoItemDto
{
    public string ID { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public bool Done { get; set; }
}