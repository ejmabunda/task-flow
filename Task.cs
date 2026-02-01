namespace TaskFlow;

/// <summary>
/// Represents a task in the task flow system.
/// </summary>
public class Task
{
    /// <summary>
    /// Gets or sets the unique identifier for the task.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the task.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the task.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the task is completed.
    /// </summary>
    public bool Status { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Task"/> class.
    /// </summary>
    /// <param name="title">The title of the task.</param>
    /// <param name="description">The description of the task.</param>
    public Task(string title, string description)
    {
        this.Id = Guid.NewGuid();
        this.Description = description;
        this.Status = false;
        this.Title = title;
    }

    /// <summary>
    /// Returns a string that represents the current task.
    /// </summary>
    /// <returns>A string representation of the task including status and title.</returns>
    public override string ToString()
    {
        string statusText = this.Status ? "Completed" : "Pending";
        return $"[{statusText}] {this.Title}";
    }
}
