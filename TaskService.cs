namespace TaskFlow;

/// <summary>
/// Provides services for managing tasks.
/// </summary>
public class TaskService
{
    /// <summary>
    /// Gets or sets the list of tasks.
    /// </summary>
    public List<Task> Tasks { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TaskService"/> class.
    /// </summary>
    public TaskService()
    {
        Tasks = new List<Task>();
    }
    
    /// <summary>
    /// Adds a new task to the service.
    /// </summary>
    /// <param name="title">The title of the task.</param>
    /// <param name="description">The description of the task.</param>
    public void AddTask(string title, string description)
    {
        Task task = new Task(title: title, description: description);

        Tasks.Add(task);
    }

    /// <summary>
    /// Removes a task from the service.
    /// </summary>
    /// <param name="task">The task to remove.</param>
    /// <returns>The removed task if found; otherwise, null.</returns>
    public Task? DeleteTask(Task task)
    {
        if (Tasks.Remove(task))
        {
            return task;
        }
        return null;
    }

    /// <summary>
    /// Marks a task as completed.
    /// </summary>
    /// <param name="task">The task to complete.</param>
    public void CompleteTask(Task task)
    {
        foreach (var t in Tasks)
        {
            if (t == task)
            {
                t.Status = true;
                break;
            }
        }
    }

    /// <summary>
    /// Retrieves all tasks.
    /// </summary>
    /// <returns>A list of all tasks.</returns>
    public List<Task> GetAllTasks()
    {
        return Tasks;
    }
}
