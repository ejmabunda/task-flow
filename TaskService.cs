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
        Task Tasks = new Task(title: title, description: description);

        tasks.Add(task);
    }

    /*
        Removes a task from the list of tasks.
        Returns the deleted task.
    */
    public Task? DeleteTask(Task Task)
    {
        foreach (Task item in Tasks)
        {
            if (Task == item)
            {
                Tasks.Remove(task);
                return Task;
            }
        }
        return null;
    }

    /*
        Marks a task as completed.
    */
    public void CompleteTask(Task Task)
    {
        for (int a = 0; a < Tasks.Count(); a++)
        {
            if (Tasks[a] == Task)
            {
                Tasks[a].Status = true;
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
