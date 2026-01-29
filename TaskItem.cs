namespace TaskFlow;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public TaskItem()
    {
        CreatedAt = DateTime.Now;
    }

    public override string ToString()
    {
        var status = IsCompleted ? "[✓]" : "[ ]";
        var completedInfo = IsCompleted && CompletedAt.HasValue 
            ? $" (Completed: {CompletedAt.Value:yyyy-MM-dd HH:mm})"
            : "";
        return $"{status} {Id}. {Title}{completedInfo}\n   Description: {Description}\n   Created: {CreatedAt:yyyy-MM-dd HH:mm}";
    }
}
