namespace TaskFlow;

public class TaskService
{
    public List<Task> Tasks { get; set; }

    // Constructor
    public TaskService()
    {
        Tasks = new List<Task>();
    }
    
    /*
        Adds a Task to the list of tasks
    */
    public void AddTask(string title, string description)
    {
        Task Task = new Task(title: title, description: description);

        Tasks.Add(Task);
    }

    /*
        Removes a task from the list of tasks.
        Returns the deleted task.
    */
    public Task? DeleteTask(Task Task)
    {
        if (Tasks.Remove(Task))
        {
            return Task;
        }
        return null;
    }

    /*
        Marks a task as completed.
    */
    public void CompleteTask(Task Task)
    {
        foreach (var t in Tasks)
        {
            if (t == Task)
            {
                t.status = true;
                break;
            }
        }
    }

    /*
        Return a list of all tasks
    */
    public List<Task> GetAllTasks()
    {
        return Tasks;
    }
}
