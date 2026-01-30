namespace TaskFlow;

public class TaskService
{
    public List<Task> tasks { get; set; }

    // Constructor
    public TaskService()
    {
        tasks = new List<Task>();
    }
    
    /*
        Adds a Task to the list of tasks
    */
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    /*
        Removes a task from the list of tasks.
        Returns the deleted task.
    */
    public Task DeleteTask(Task task)
    {
        if (tasks.Remove(task))
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
        for (int a = 0; a < tasks.Count(); a++)
        {
            if (tasks[a] == task)
            {
                tasks[a].status = true;
                break;
            }
        }
    }

    public List<Task> GetAllTasks()
    {
        return tasks;
    }
}