namespace TaskFlow;
public class Task
{
    public Guid id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public bool status { get; set; }

    public Task(string title, string description)
    {
        this.id = new Guid();
        this.description = description;
        this.status = false;
    }
}