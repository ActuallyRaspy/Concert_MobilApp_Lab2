namespace Todo.MAUI.Models
{
    public class TodoItem
    {
        public string ID { get; set; } = null!;
        public string TaskName { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public bool Done { get; set; }
    }
}