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
        Task task = new Task(title: title, description: description);

        Tasks.Add(task);
    }

    /*
        Removes a task from the list of tasks.
        Returns the deleted task.
    */
    public Task? DeleteTask(Task task)
    {
        if (Tasks.Remove(task))
        {
            return task;
        }
        return null;
    }

    /*
        Marks a task as completed.
    */
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

    /*
        Return a list of all tasks
    */
    public List<Task> GetAllTasks()
    {
        return Tasks;
    }
}
