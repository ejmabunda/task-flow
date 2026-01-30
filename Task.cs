namespace TaskFlow;
public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }

    public Task(string title, string description)
    {
        this.Id = Guid.NewGuid();
        this.Description = description;
        this.Status = false;
        this.Title = title;
    }
}